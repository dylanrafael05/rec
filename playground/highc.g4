grammar highc;

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
    : top_level_statement*
    ;

top_level_statement
    : fn_define
    | struct_define
    | alias_define
    | let_statement
    | mod_statement
    | use_statement
    ;

mod_statement
    : Mod (parts+=Identifier ('.' parts+=Identifier)*)
    ;

use_statement
    : Use (parts+=Identifier ('.' parts+=Identifier)*)
    ;

template_header
    : Template (args+=Identifier)+
    ;

struct_define_field
    : Let name=Identifier type=typename
    ;

struct_define
    : template_header? Struct name=Identifier '{' fields+=struct_define_field* '}'
    ;

fn_define_argument
    : auto=Auto? Identifier typename
    ;

fn_define
    : template_header? Fn name=Identifier 
      '(' (args+=fn_define_argument (',' args+=fn_define_argument)*)? ')'
      ret=typename?
      block
    ;

alias_define
    : Type name=Identifier '=' typename
    ;

block
    : '{' stmts+=statement* '}'
    ;

statement
    : assign_statement
    | let_statement
    | if_statement
    | while_statement
    | defer_statement
    | return_statement
    | Continue
    | Break
    | block
    | expression
    ;

return_statement
    : Return value=expression;

defer_statement
    : Defer block;

if_statement
    : If cond=expression block if_tail_statement?;

if_tail_statement
    : Else end_block=block
    | Else elif=if_statement
    ;
    
while_statement
    : While cond=expression block;

assign_statement
    : target=expression '=' value=expression
    ;

let_expression 
    : Uninit
    | expression;

let_statement
    : spec=(Let|Var) target=Identifier type=typename? '=' value=let_expression
    ;

typename_fn_args
    : Identifier? type=typename
    ;

typename
    : Identifier #TypenameSingle
    | '(' inner=typename ')' #TypenameSingle
    | parts+=Identifier ('.' parts+=Identifier)+ #TypenameMany
    | base=typename '\'' (args+=typename)+ '\'' #TypenameGeneric
    | '*' base=typename #TypenamePointer
    | '[' base=typename (';' count=Integer)? ']' #TypenameArray
    | Fn '(' (args+=typename_fn_args (',' args+=typename_fn_args)*)? ')' ret=typename? #TypenameFn
    ;

expression
    : op_expression
    ;

op_expression
    : lhs=op_expression (And | Or) lhs=op_expression #LogicExpression
    | lhs=op_expression ('==' | '!=' | '>' | '<' | '<=' | '>=') lhs=op_expression #CompareExpression
    | lhs=op_expression ('*' | '/') lhs=op_expression #MulExpression
    | rhs=op_expression ('&' | '|' | '>>' | '<<') rhs=op_expression #BitwiseExpression
    | rhs=op_expression ('+' | '-') rhs=op_expression #AddExpression
    | ('+' | '-' | '~' | Not) op=op_expression #UnaryExpression
    | op=op_expression ('*' | '&') #MemoryExpression
    | call_expression #CallExpression
    ;

explicit_template_instantiation
    : '\'' args+=typename* '\''
    ;

call_expression
    : target=call_expression inst=explicit_template_instantiation? 
      '(' (args+=expression (',' args+=expression)*)? ')'
    | dot_expression
    ;

struct_expression
    : New typename '{' parts+=struct_expression_set+ '}'
    ;

struct_expression_set
    : Let Identifier '=' expression
    ;

dot_expression
    : dot_expression '.' field=Identifier
    | term_expression
    ;

term_expression
    : literal
    | Identifier
    | '(' expression ')'
    | struct_expression
    ;

literal 
    : Integer
    | Float
    | String
    | boolean_literal
    ;

boolean_literal
    : True
    | False
    ;