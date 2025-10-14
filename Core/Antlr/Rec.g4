grammar Rec;

options 
{
    language=CSharp;
}

@lexer::members
{
    public required Re.C.Vocabulary.Source Source { get; init; }
}

@parser::members
{
    public int LoopDepth { get; set; }
    public bool InLoop => LoopDepth > 0;
}

// Lexer rules //
fragment LETTER : [_A-Za-z];
fragment DIGIT : [0-9];
fragment CHAR
    : ~[\\\n]
    | '\\' ["rnte0]
    ;

Whitespace : [ \t\n\r] -> skip;
SLComment : '//' ~[\r\n]* -> skip;
MLComment : '/*' .*? '*/' -> skip;

Var      : 'var';
Let      : 'let';
End      : 'end';
If       : 'if';
Else     : 'else';
While    : 'while';
Fn       : 'fn';
Continue : 'continue';
Break    : 'break';
Defer    : 'defer';
Type     : 'type';
Struct   : 'struct';
Template : 'template';
New      : 'new';
Return   : 'return';
For      : 'for';
Mod      : 'mod';
Use      : 'use';
Auto     : 'auto';
And      : 'and';
Not      : 'not';
Or       : 'or';
True     : 'true';
False    : 'false';
Uninit   : 'uninit';
As       : 'as';
Cast     : 'cast';

Identifier : LETTER+ (DIGIT | LETTER)*;

Integer : DIGIT+;
Float   : DIGIT* (DIGIT '.' | '.' DIGIT) DIGIT*;
String  : '"' CHAR* '"';

Plus : '+';
Minus : '-';
Star : '*';
Slash : '/';
Ampersand : '&';

Equal : '=';

CompEqual : '==';

OpenParen  : '(';
CloseParen : ')';

OpenBrace  : '{';
CloseBrace : '}';

OpenIndex  : '[';
CloseIndex : ']';

// Parser rules
program
    : topLevelStatement* EOF
    ;

topLevelStatement
    : fnDefine
    | structDefine
    | aliasDefine
    | letStatement
    | modStatement
    | asStatement
    | useStatement
    ;

asStatement
    : As typename Identifier* 
        topLevelStatement*
      End As
    ;

simpleScopedIdentifier
    : (Parts+=Identifier ('.' Parts+=Identifier)*);

modStatement
locals [
    Re.C.Definitions.Scope? Scope = null
]
    : Mod ModuleIdent=simpleScopedIdentifier
        Substatements+=topLevelStatement*
      (End Mod)?
    ;

useStatement
locals [
    Re.C.Definitions.Scope? ImportedScope = null
]
    : Use Ident=simpleScopedIdentifier
    ;

templateHeader
    : Template (Args+=Identifier)+
    ;

structFieldDefine
    : Name=Identifier FieldType=typename
    ;

structDefine
locals [
    Re.C.Types.StructType? DefinedType = null
]
    : templateHeader? Struct Name=Identifier '{' 
        (Fields+=structFieldDefine ',' )*
        (Fields+=structFieldDefine ','?)?
      '}'
    ;

fnArgumentDefine
    : Identifier typename
    ;

fnDefine
locals [
    Re.C.Definitions.Function? DefinedFunction = null,
    Re.C.Syntax.Block? BoundBody = null
]
    : templateHeader? Fn Name=Identifier 
      '(' (Args+=fnArgumentDefine (',' Args+=fnArgumentDefine)*)? ')'
      Ret=typename?
      Body=block
    ;

aliasDefine
    : Type Name=Identifier '=' typename
    ;

// Statements //
statement
    : assignStatement ';'
    | letStatement ';'
    | ifStatement
    | whileStatement
    | deferStatement ';'
    | returnStatement ';'
    | continueStatement ';'
    | breakStatement ';'
    | block
    | expression ';'
    ;
    
block
    : '{' Statements+=statement* '}'
    ;

continueStatement
    : {InLoop}? Continue;

breakStatement
    : {InLoop}? Break;

returnStatement
    : Return Value=expression;

deferStatement
    : Defer block;

ifStatement
    : If Cond=expression Body=block Tail=ifTail?;

ifTail
    : Else EndBlock=block       #ElseStatement
    | Else Elif=ifStatement     #ElifStatement
    ;
    
whileStatement
    : While Cond=expression 
      {LoopDepth++;} 
        Body=block 
      {LoopDepth--;};

assignStatement
    : Target=expression '=' Value=expression
    ;

letStatement
    : Spec=(Let|Var) Target=Identifier VarType=typename? '=' Value=expression
    ;

// Typename syntax //
typenameFnArgs
    : Identifier? ArgType=typename
    ;

typename
    : Ident=simpleScopedIdentifier 
        #TypenameSingle
    | '(' Inner=typename ')' 
        #TypenameWrapped
    | '(' Base=typename (Args+=typename)+ ')' 
        #TypenameGeneric
    | '*' Base=typename 
        #TypenamePointer
    | '[' Base=typename (';' Count=Integer)? ']' 
        #TypenameArray
    | Fn '(' (Args+=typenameFnArgs (',' Args+=typenameFnArgs)*)? ')' Ret=typename? 
        #TypenameFn
    ;

// Define operators //
logicalOperator
    : And #AndOperator
    | Or  #OrOperator
    ;

compOperator 
    : '==' #EqualsOperator
    | '!=' #NotEqualsOperator
    | '>'  #GreaterThanOperator
    | '<'  #LessThanOperator
    | '<=' #GreaterEqualOperator
    | '>=' #LessEqualOperator
    ;

muldivOperator
    : '*' #MulOperator
    | '/' #DivOperator
    ;

bitwiseOperator
    : '&'     #BitAndOperator
    | '|'     #BitOrOperator
    | '^'     #BitXorOperator
    | '<' '<' #BitShiftLeftOperator
    | '>' '>' #BitShiftRightOperator
    ;

addsubOperator
    : '+' #AddOperator
    | '-' #SubOperator
    ;

unaryOperator
    : '+' #PositOperator
    | '-' #NegateOperator
    | '~' #BitNotOperator
    ;

memoryOperator
    : '*' #DereferenceOperator
    | '&' #AddressofOperator
    ;

// Main expression format //
expression
    : LHS=expression logicalOperator RHS=expression       #BinaryExpression
    | LHS=expression compOperator    RHS=expression       #BinaryExpression
    | LHS=expression bitwiseOperator RHS=expression       #BinaryExpression
    | LHS=expression muldivOperator  RHS=expression       #BinaryExpression
    | LHS=expression addsubOperator  RHS=expression       #BinaryExpression
    | Operand=expression Cast '(' TargetType=typename ')' #CastExpression
    | Op=unaryOperator Operand=expression                 #UnaryExpression
    | Operand=expression Op=memoryOperator                #MemoryExpression
    | Target=expression TemplateInst=templateInstantiation? 
      '(' (Args+=expression (',' Args+=expression)*)? ')' #CallExpression
    | Base=expression '.' Field=dotComponent              #DotExpression
    | term                                                #TermExpression
    ;

templateInstantiation
    : '\'' args+=typename* '\''
    ;
    
structExprAssign
    : Field=Identifier '=' Value=expression
    ;

structExpression
    : New StructType=typename '{' Parts+=structExprAssign+ '}'
    ;

dotComponent
    : Identifier
    | Identifier As typename
    ;

variableReference
    : Identifier
    | Identifier As typename
    ;

term
    : literal                
    | variableReference
    | '(' expression ')'     
    | structExpression      
    ;

literal 
    : Integer       #IntegerLiteral
    | Float         #FloatLiteral
    | String        #StringLiteral
    | True          #BoolLiteral
    | False         #BoolLiteral
    ;