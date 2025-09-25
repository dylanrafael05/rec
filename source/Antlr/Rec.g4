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
    : topLevelStatement*
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

modStatement
    : Mod (parts+=Identifier ('.' parts+=Identifier)*)
        topLevelStatement*
      (End Mod)?
    ;

useStatement
    : Use (parts+=Identifier ('.' parts+=Identifier)*)
    ;

templateHeader
    : Template (args+=Identifier)+
    ;

structFieldDefine
    : name=Identifier type=typename
    ;

structDefine
    : templateHeader? Struct name=Identifier '{' 
        (fields+=structFieldDefine ',' )*
        (fields+=structFieldDefine ','?)?
      '}'
    ;

fnArgumentDefine
    : auto=Auto? Identifier typename
    ;

fnDefine
    : templateHeader? Fn name=Identifier 
      '(' (args+=fnArgumentDefine (',' args+=fnArgumentDefine)*)? ')'
      ret=typename?
      block
    ;

aliasDefine
    : Type name=Identifier '=' typename
    ;

block
    : '{' stmts+=statement* '}'
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
    : Return value=expr;

deferStmt
    : Defer block;

ifStmt
    : If cond=expr block ifTail?;

ifTail
    : Else end_block=block
    | Else elif=ifStmt
    ;
    
whileStmt
    : While cond=expr block;

assignStmt
    : target=expr '=' value=expr
    ;

letExpr 
    : Uninit
    | expr;

letStmt
    : spec=(Let|Var) target=Identifier type=typename? '=' value=letExpr
    ;

typenameFnArgs
    : Identifier? type=typename
    ;

typename
    : Identifier #TypenameSingle
    | '(' inner=typename ')' #TypenameSingle
    | parts+=Identifier ('.' parts+=Identifier)+ #TypenameMany
    | '(' base=typename (args+=typename)+ ')' #TypenameGeneric
    | '*' base=typename #TypenamePointer
    | '[' base=typename (';' count=Integer)? ']' #TypenameArray
    | Fn '(' (args+=typenameFnArgs (',' args+=typenameFnArgs)*)? ')' ret=typename? #TypenameFn
    ;

expr
    : opExpr
    ;

opExpr
    : lhs=opExpr (And | Or) lhs=opExpr #LogicExpression
    | lhs=opExpr ('==' | '!=' | '>' | '<' | '<=' | '>=') lhs=opExpr #CompareExpression
    | lhs=opExpr ('*' | '/') lhs=opExpr #MulExpression
    | rhs=opExpr ('&' | '|' | '>>' | '<<') rhs=opExpr #BitwiseExpression
    | rhs=opExpr ('+' | '-') rhs=opExpr #AddExpression
    | ('+' | '-' | '~' | Not) op=opExpr #UnaryExpression
    | op=opExpr ('*' | '&') #MemoryExpression
    | callExpr #CallExpression
    ;

explicitTemplateInstatiation
    : '\'' args+=typename* '\''
    ;

callExpr
    : target=callExpr inst=explicitTemplateInstatiation? 
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
    : Integer
    | Float
    | String
    | boolLiteral
    ;

boolLiteral
    : True
    | False
    ;