grammar Rec;

options 
{
    language=CSharp;
}

@lexer::members
{
    public required Re.C.Vocabulary.Source Source { get; init; }
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
    | letStmt
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
    Re.C.Syntax.BoundSyntax[]? BoundStatements = null
]
    : templateHeader? Fn Name=Identifier 
      '(' (Args+=fnArgumentDefine (',' Args+=fnArgumentDefine)*)? ')'
      Ret=typename?
      Body=block
    ;

aliasDefine
    : Type Name=Identifier '=' typename
    ;

block
    : '{' Statements+=statement* '}'
    ;

statement
    : assignStmt
    | letStmt
    | ifStmt
    | whileStmt
    | deferStmt
    | returnStmt
    | Continue
    | Break
    | block
    | expr
    ;

returnStmt
    : Return Value=expr;

deferStmt
    : Defer block;

ifStmt
    : If Cond=expr block ifTail?;

ifTail
    : Else EndBlock=block
    | Else Elif=ifStmt
    ;
    
whileStmt
    : While Cond=expr block;

assignStmt
    : Target=expr '=' Value=expr
    ;

letExpr 
    : Uninit
    | expr;

letStmt
    : Spec=(Let|Var) Target=Identifier VarType=typename? '=' Value=letExpr
    ;

typenameFnArgs
    : Identifier? ArgType=typename
    ;

typename
    : Ident=simpleScopedIdentifier #TypenameSingle
    | '(' Inner=typename ')' #TypenameWrapped
    | '(' Base=typename (Args+=typename)+ ')' #TypenameGeneric
    | '*' Base=typename #TypenamePointer
    | '[' Base=typename (';' Count=Integer)? ']' #TypenameArray
    | Fn '(' (Args+=typenameFnArgs (',' Args+=typenameFnArgs)*)? ')' Ret=typename? #TypenameFn
    ;

expr
    : opExpr
    ;

opExpr
    : LHS=opExpr (And | Or) RHS=opExpr #LogicExpression
    | LHS=opExpr ('==' | '!=' | '>' | '<' | '<=' | '>=') RHS=opExpr #CompareExpression
    | LHS=opExpr ('*' | '/') RHS=opExpr #MulExpression
    | LHS=opExpr ('&' | '|' | '>>' | '<<') RHS=opExpr #BitwiseExpression
    | LHS=opExpr ('+' | '-') RHS=opExpr #AddExpression
    | ('+' | '-' | '~' | Not) Operand=opExpr #UnaryExpression
    | Operand=opExpr ('*' | '&') #MemoryExpression
    | castExpr #CastExpression
    ;

castExpr
    : Operand=callExpr Cast TargetType=typename
    ;

explicitTemplateInstatiation
    : '\'' args+=typename* '\''
    ;

callExpr
    : Target=callExpr TemplateInst=explicitTemplateInstatiation? 
      '(' (args+=expr (',' args+=expr)*)? ')'
    | dotExpr
    ;

structExpr
    : New typename '{' parts+=structExprAssign+ '}'
    ;

structExprAssign
    : Field=Identifier '=' Value=expr
    ;

dotComponent
    : Identifier
    | Identifier As typename
    ;

dotExpr
    : dotExpr '.' Field=dotComponent
    | termExpr
    ;

termExpr
    : literal
    | Identifier
    | Identifier As typename
    | '(' expr ')'
    | structExpr
    ;

literal 
    : Integer       #IntegerLiteral
    | Float         #FloatLiteral
    | String        #StringLiteral
    | True          #BoolLiteral
    | False         #BoolLiteral
    ;