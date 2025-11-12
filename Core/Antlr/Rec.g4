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

    public int AsBlockDepth { get; set; }
    public bool InAsBlock => AsBlockDepth > 0;
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
Self     : 'self';
And      : 'and';
Not      : 'not';
Or       : 'or';
True     : 'true';
False    : 'false';
Uninit   : 'uninit';
As       : 'as';
Cast     : 'cast';
External : 'external';

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
    : useStatement* 
      topLevelStatement* 
      EOF
    ;

topLevelStatement
    : fnDefine
    | { !InAsBlock }? structDefine
    | { !InAsBlock }? aliasDefine
    | { !InAsBlock }? letStatement
    | { !InAsBlock }? modStatement
    | { !InAsBlock }? asStatement
    ;

asStatement
locals [
    Re.C.Types.RecType AsType = null,
    Re.C.Definitions.Scope Scope = null
]
@init  { AsBlockDepth++; }
@after { AsBlockDepth--; }
    : {AsBlockDepth <= 1}? 
      Mod ModuleIdent=Identifier? As typename
        Substatements+=topLevelStatement*
      (End Mod)?
    ;

fullIdentifier
    : ((Parts+=Identifier '::')* Parts+=Identifier);

modStatement
locals [
    Re.C.Definitions.Scope Scope = null
]
    : Mod ModuleIdent=fullIdentifier
        Substatements+=topLevelStatement*
      (End Mod)?
    ;

useStatement
locals [
    Re.C.Definitions.Scope ImportedScope = null
]
    : Use Ident=fullIdentifier
    ;

templateHeader
    : Template (Args+=Identifier)+
    ;

structFieldDefine
    : Name=Identifier FieldType=typename
    ;

structDefine
locals [
    Re.C.Types.StructType DefinedType = null
]
    : templateHeader? Struct Name=Identifier '{' 
        (Fields+=structFieldDefine ',' )*
        (Fields+=structFieldDefine ','?)?
      '}'
    ;

fnArgumentDefine
    : Identifier typename
    ;

fnSelfDefine
    : { InAsBlock }? Self      #FnDefineSelf
    | { InAsBlock }? '*' Self  #FnDefineSelfPtr
    ;

fnDefine
locals [
    Re.C.Definitions.Function DefinedFunction = null,
    Re.C.Syntax.Block BoundBody = null
]
    : templateHeader? 
      External? Fn Name=Identifier 
      '('( 
        ((fnSelfDefine ',')? Args+=fnArgumentDefine (',' Args+=fnArgumentDefine)*) 
        | fnSelfDefine
      )?')'
      Ret=typename?
      Body=block?
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
    | breakStructStatement ';'
    ;

breakStructPart
    : Let Name=Identifier '=' Field=Identifier
    ;

breakStructStatement
    : Break Target=expression '{' (Parts+=breakStructPart ',')* (Parts+=breakStructPart)? '}'
    ;
    
block
    : '{' Statements+=statement* '}'
    ;

continueStatement
    : {InLoop}? Continue;

breakStatement
    : {InLoop}? Break;

returnStatement
    : Return Value=expression?;

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
    : Ident=fullIdentifier 
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
    | Not #LogicNotOperator
    ;

memoryOperator
    : '*' #DereferenceOperator
    | '&' #AddressofOperator
    ;

// Main expression format //
expression
    : Base=expression 
        {TokenStream.LT(3).Text != "("}? 
        // NOTE: this ^^ is a somewhat hacky fix to ensure
        //       that method calls are appropriately parsed
        '.' Field=Identifier                              #DotExpression
    | Operand=expression Op=memoryOperator                #MemoryExpression
    | Target=expression ('.' MethodMarker=Identifier)? 
      '(' (Args+=expression (',' Args+=expression)*)? ')' #CallExpression
    | Op=unaryOperator Operand=expression                 #UnaryExpression
    | Operand=expression Cast '(' TargetType=typename ')' #CastExpression
    | LHS=expression logicalOperator RHS=expression       #BinaryExpression
    | LHS=expression compOperator    RHS=expression       #BinaryExpression
    | LHS=expression bitwiseOperator RHS=expression       #BinaryExpression
    | LHS=expression muldivOperator  RHS=expression       #BinaryExpression
    | LHS=expression addsubOperator  RHS=expression       #BinaryExpression
    | term                                                #TermExpression
    ;
    
structExprAssign
    : Field=Identifier '=' Value=expression
    ;

structExpression
    : New StructType=typename '{' (Parts+=structExprAssign ',')* (Parts+=structExprAssign)? '}'
    ;

variableReference
    : Identifier
    | fullIdentifier
    | {InAsBlock}? Self
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