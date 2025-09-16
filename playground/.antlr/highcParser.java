// Generated from c:/Users/rafaed/Desktop/Programming/highc/highc.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class highcParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, Whitespace=14, SLComment=15, MLComment=16, 
		Var=17, Let=18, If=19, Else=20, While=21, Fn=22, Continue=23, Break=24, 
		Defer=25, Type=26, Struct=27, Template=28, New=29, Return=30, For=31, 
		Mod=32, Use=33, Auto=34, And=35, Not=36, Or=37, True=38, False=39, Uninit=40, 
		Identifier=41, Integer=42, Float=43, String=44, Plus=45, Minus=46, Star=47, 
		Slash=48, Ampersand=49, Equal=50, CompEqual=51, OpenParen=52, CloseParen=53, 
		OpenBrace=54, CloseBrace=55, OpenIndex=56, CloseIndex=57;
	public static final int
		RULE_program = 0, RULE_top_level_statement = 1, RULE_mod_statement = 2, 
		RULE_use_statement = 3, RULE_template_header = 4, RULE_struct_define_field = 5, 
		RULE_struct_define = 6, RULE_fn_define_argument = 7, RULE_fn_define = 8, 
		RULE_alias_define = 9, RULE_block = 10, RULE_statement = 11, RULE_return_statement = 12, 
		RULE_defer_statement = 13, RULE_if_statement = 14, RULE_if_tail_statement = 15, 
		RULE_while_statement = 16, RULE_assign_statement = 17, RULE_let_expression = 18, 
		RULE_let_statement = 19, RULE_typename_fn_args = 20, RULE_typename = 21, 
		RULE_expression = 22, RULE_op_expression = 23, RULE_explicit_template_instantiation = 24, 
		RULE_call_expression = 25, RULE_struct_expression = 26, RULE_struct_expression_set = 27, 
		RULE_dot_expression = 28, RULE_term_expression = 29, RULE_literal = 30, 
		RULE_boolean_literal = 31;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "top_level_statement", "mod_statement", "use_statement", "template_header", 
			"struct_define_field", "struct_define", "fn_define_argument", "fn_define", 
			"alias_define", "block", "statement", "return_statement", "defer_statement", 
			"if_statement", "if_tail_statement", "while_statement", "assign_statement", 
			"let_expression", "let_statement", "typename_fn_args", "typename", "expression", 
			"op_expression", "explicit_template_instantiation", "call_expression", 
			"struct_expression", "struct_expression_set", "dot_expression", "term_expression", 
			"literal", "boolean_literal"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "','", "'''", "';'", "'!='", "'>'", "'<'", "'<='", "'>='", 
			"'|'", "'>>'", "'<<'", "'~'", null, null, null, "'var'", "'let'", "'if'", 
			"'else'", "'while'", "'fn'", "'continue'", "'break'", "'defer'", "'type'", 
			"'struct'", "'template'", "'new'", "'return'", "'for'", "'mod'", "'use'", 
			"'auto'", "'and'", "'not'", "'or'", "'true'", "'false'", "'uninit'", 
			null, null, null, null, "'+'", "'-'", "'*'", "'/'", "'&'", "'='", "'=='", 
			"'('", "')'", "'{'", "'}'", "'['", "']'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, "Whitespace", "SLComment", "MLComment", "Var", "Let", "If", 
			"Else", "While", "Fn", "Continue", "Break", "Defer", "Type", "Struct", 
			"Template", "New", "Return", "For", "Mod", "Use", "Auto", "And", "Not", 
			"Or", "True", "False", "Uninit", "Identifier", "Integer", "Float", "String", 
			"Plus", "Minus", "Star", "Slash", "Ampersand", "Equal", "CompEqual", 
			"OpenParen", "CloseParen", "OpenBrace", "CloseBrace", "OpenIndex", "CloseIndex"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "highc.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public highcParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends ParserRuleContext {
		public List<Top_level_statementContext> top_level_statement() {
			return getRuleContexts(Top_level_statementContext.class);
		}
		public Top_level_statementContext top_level_statement(int i) {
			return getRuleContext(Top_level_statementContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(67);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 13359251456L) != 0)) {
				{
				{
				setState(64);
				top_level_statement();
				}
				}
				setState(69);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Top_level_statementContext extends ParserRuleContext {
		public Fn_defineContext fn_define() {
			return getRuleContext(Fn_defineContext.class,0);
		}
		public Struct_defineContext struct_define() {
			return getRuleContext(Struct_defineContext.class,0);
		}
		public Alias_defineContext alias_define() {
			return getRuleContext(Alias_defineContext.class,0);
		}
		public Let_statementContext let_statement() {
			return getRuleContext(Let_statementContext.class,0);
		}
		public Mod_statementContext mod_statement() {
			return getRuleContext(Mod_statementContext.class,0);
		}
		public Use_statementContext use_statement() {
			return getRuleContext(Use_statementContext.class,0);
		}
		public Top_level_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_top_level_statement; }
	}

	public final Top_level_statementContext top_level_statement() throws RecognitionException {
		Top_level_statementContext _localctx = new Top_level_statementContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_top_level_statement);
		try {
			setState(76);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(70);
				fn_define();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(71);
				struct_define();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(72);
				alias_define();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(73);
				let_statement();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(74);
				mod_statement();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(75);
				use_statement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Mod_statementContext extends ParserRuleContext {
		public Token Identifier;
		public List<Token> parts = new ArrayList<Token>();
		public TerminalNode Mod() { return getToken(highcParser.Mod, 0); }
		public List<TerminalNode> Identifier() { return getTokens(highcParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(highcParser.Identifier, i);
		}
		public Mod_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_mod_statement; }
	}

	public final Mod_statementContext mod_statement() throws RecognitionException {
		Mod_statementContext _localctx = new Mod_statementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_mod_statement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(78);
			match(Mod);
			{
			setState(79);
			((Mod_statementContext)_localctx).Identifier = match(Identifier);
			((Mod_statementContext)_localctx).parts.add(((Mod_statementContext)_localctx).Identifier);
			setState(84);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(80);
				match(T__0);
				setState(81);
				((Mod_statementContext)_localctx).Identifier = match(Identifier);
				((Mod_statementContext)_localctx).parts.add(((Mod_statementContext)_localctx).Identifier);
				}
				}
				setState(86);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Use_statementContext extends ParserRuleContext {
		public Token Identifier;
		public List<Token> parts = new ArrayList<Token>();
		public TerminalNode Use() { return getToken(highcParser.Use, 0); }
		public List<TerminalNode> Identifier() { return getTokens(highcParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(highcParser.Identifier, i);
		}
		public Use_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_use_statement; }
	}

	public final Use_statementContext use_statement() throws RecognitionException {
		Use_statementContext _localctx = new Use_statementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_use_statement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(87);
			match(Use);
			{
			setState(88);
			((Use_statementContext)_localctx).Identifier = match(Identifier);
			((Use_statementContext)_localctx).parts.add(((Use_statementContext)_localctx).Identifier);
			setState(93);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(89);
				match(T__0);
				setState(90);
				((Use_statementContext)_localctx).Identifier = match(Identifier);
				((Use_statementContext)_localctx).parts.add(((Use_statementContext)_localctx).Identifier);
				}
				}
				setState(95);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Template_headerContext extends ParserRuleContext {
		public Token Identifier;
		public List<Token> args = new ArrayList<Token>();
		public TerminalNode Template() { return getToken(highcParser.Template, 0); }
		public List<TerminalNode> Identifier() { return getTokens(highcParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(highcParser.Identifier, i);
		}
		public Template_headerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_template_header; }
	}

	public final Template_headerContext template_header() throws RecognitionException {
		Template_headerContext _localctx = new Template_headerContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_template_header);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			match(Template);
			setState(98); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(97);
				((Template_headerContext)_localctx).Identifier = match(Identifier);
				((Template_headerContext)_localctx).args.add(((Template_headerContext)_localctx).Identifier);
				}
				}
				setState(100); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==Identifier );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Struct_define_fieldContext extends ParserRuleContext {
		public Token name;
		public TypenameContext type;
		public TerminalNode Let() { return getToken(highcParser.Let, 0); }
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public Struct_define_fieldContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_struct_define_field; }
	}

	public final Struct_define_fieldContext struct_define_field() throws RecognitionException {
		Struct_define_fieldContext _localctx = new Struct_define_fieldContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_struct_define_field);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			match(Let);
			setState(103);
			((Struct_define_fieldContext)_localctx).name = match(Identifier);
			setState(104);
			((Struct_define_fieldContext)_localctx).type = typename(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Struct_defineContext extends ParserRuleContext {
		public Token name;
		public Struct_define_fieldContext struct_define_field;
		public List<Struct_define_fieldContext> fields = new ArrayList<Struct_define_fieldContext>();
		public TerminalNode Struct() { return getToken(highcParser.Struct, 0); }
		public TerminalNode OpenBrace() { return getToken(highcParser.OpenBrace, 0); }
		public TerminalNode CloseBrace() { return getToken(highcParser.CloseBrace, 0); }
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public Template_headerContext template_header() {
			return getRuleContext(Template_headerContext.class,0);
		}
		public List<Struct_define_fieldContext> struct_define_field() {
			return getRuleContexts(Struct_define_fieldContext.class);
		}
		public Struct_define_fieldContext struct_define_field(int i) {
			return getRuleContext(Struct_define_fieldContext.class,i);
		}
		public Struct_defineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_struct_define; }
	}

	public final Struct_defineContext struct_define() throws RecognitionException {
		Struct_defineContext _localctx = new Struct_defineContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_struct_define);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Template) {
				{
				setState(106);
				template_header();
				}
			}

			setState(109);
			match(Struct);
			setState(110);
			((Struct_defineContext)_localctx).name = match(Identifier);
			setState(111);
			match(OpenBrace);
			setState(115);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==Let) {
				{
				{
				setState(112);
				((Struct_defineContext)_localctx).struct_define_field = struct_define_field();
				((Struct_defineContext)_localctx).fields.add(((Struct_defineContext)_localctx).struct_define_field);
				}
				}
				setState(117);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(118);
			match(CloseBrace);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Fn_define_argumentContext extends ParserRuleContext {
		public Token auto;
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Auto() { return getToken(highcParser.Auto, 0); }
		public Fn_define_argumentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fn_define_argument; }
	}

	public final Fn_define_argumentContext fn_define_argument() throws RecognitionException {
		Fn_define_argumentContext _localctx = new Fn_define_argumentContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_fn_define_argument);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(121);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Auto) {
				{
				setState(120);
				((Fn_define_argumentContext)_localctx).auto = match(Auto);
				}
			}

			setState(123);
			match(Identifier);
			setState(124);
			typename(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Fn_defineContext extends ParserRuleContext {
		public Token name;
		public Fn_define_argumentContext fn_define_argument;
		public List<Fn_define_argumentContext> args = new ArrayList<Fn_define_argumentContext>();
		public TypenameContext ret;
		public TerminalNode Fn() { return getToken(highcParser.Fn, 0); }
		public TerminalNode OpenParen() { return getToken(highcParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(highcParser.CloseParen, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public Template_headerContext template_header() {
			return getRuleContext(Template_headerContext.class,0);
		}
		public List<Fn_define_argumentContext> fn_define_argument() {
			return getRuleContexts(Fn_define_argumentContext.class);
		}
		public Fn_define_argumentContext fn_define_argument(int i) {
			return getRuleContext(Fn_define_argumentContext.class,i);
		}
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public Fn_defineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fn_define; }
	}

	public final Fn_defineContext fn_define() throws RecognitionException {
		Fn_defineContext _localctx = new Fn_defineContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_fn_define);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Template) {
				{
				setState(126);
				template_header();
				}
			}

			setState(129);
			match(Fn);
			setState(130);
			((Fn_defineContext)_localctx).name = match(Identifier);
			setState(131);
			match(OpenParen);
			setState(140);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Auto || _la==Identifier) {
				{
				setState(132);
				((Fn_defineContext)_localctx).fn_define_argument = fn_define_argument();
				((Fn_defineContext)_localctx).args.add(((Fn_defineContext)_localctx).fn_define_argument);
				setState(137);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__1) {
					{
					{
					setState(133);
					match(T__1);
					setState(134);
					((Fn_defineContext)_localctx).fn_define_argument = fn_define_argument();
					((Fn_defineContext)_localctx).args.add(((Fn_defineContext)_localctx).fn_define_argument);
					}
					}
					setState(139);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(142);
			match(CloseParen);
			setState(144);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
				{
				setState(143);
				((Fn_defineContext)_localctx).ret = typename(0);
				}
			}

			setState(146);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Alias_defineContext extends ParserRuleContext {
		public Token name;
		public TerminalNode Type() { return getToken(highcParser.Type, 0); }
		public TerminalNode Equal() { return getToken(highcParser.Equal, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public Alias_defineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_alias_define; }
	}

	public final Alias_defineContext alias_define() throws RecognitionException {
		Alias_defineContext _localctx = new Alias_defineContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_alias_define);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(148);
			match(Type);
			setState(149);
			((Alias_defineContext)_localctx).name = match(Identifier);
			setState(150);
			match(Equal);
			setState(151);
			typename(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BlockContext extends ParserRuleContext {
		public StatementContext statement;
		public List<StatementContext> stmts = new ArrayList<StatementContext>();
		public TerminalNode OpenBrace() { return getToken(highcParser.OpenBrace, 0); }
		public TerminalNode CloseBrace() { return getToken(highcParser.CloseBrace, 0); }
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(153);
			match(OpenBrace);
			setState(157);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 22657431627505664L) != 0)) {
				{
				{
				setState(154);
				((BlockContext)_localctx).statement = statement();
				((BlockContext)_localctx).stmts.add(((BlockContext)_localctx).statement);
				}
				}
				setState(159);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(160);
			match(CloseBrace);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementContext extends ParserRuleContext {
		public Assign_statementContext assign_statement() {
			return getRuleContext(Assign_statementContext.class,0);
		}
		public Let_statementContext let_statement() {
			return getRuleContext(Let_statementContext.class,0);
		}
		public If_statementContext if_statement() {
			return getRuleContext(If_statementContext.class,0);
		}
		public While_statementContext while_statement() {
			return getRuleContext(While_statementContext.class,0);
		}
		public Defer_statementContext defer_statement() {
			return getRuleContext(Defer_statementContext.class,0);
		}
		public Return_statementContext return_statement() {
			return getRuleContext(Return_statementContext.class,0);
		}
		public TerminalNode Continue() { return getToken(highcParser.Continue, 0); }
		public TerminalNode Break() { return getToken(highcParser.Break, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_statement);
		try {
			setState(172);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(162);
				assign_statement();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(163);
				let_statement();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(164);
				if_statement();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(165);
				while_statement();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(166);
				defer_statement();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(167);
				return_statement();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(168);
				match(Continue);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(169);
				match(Break);
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(170);
				block();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(171);
				expression();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Return_statementContext extends ParserRuleContext {
		public ExpressionContext value;
		public TerminalNode Return() { return getToken(highcParser.Return, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Return_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_return_statement; }
	}

	public final Return_statementContext return_statement() throws RecognitionException {
		Return_statementContext _localctx = new Return_statementContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_return_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(174);
			match(Return);
			setState(175);
			((Return_statementContext)_localctx).value = expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Defer_statementContext extends ParserRuleContext {
		public TerminalNode Defer() { return getToken(highcParser.Defer, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public Defer_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_defer_statement; }
	}

	public final Defer_statementContext defer_statement() throws RecognitionException {
		Defer_statementContext _localctx = new Defer_statementContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_defer_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(177);
			match(Defer);
			setState(178);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class If_statementContext extends ParserRuleContext {
		public ExpressionContext cond;
		public TerminalNode If() { return getToken(highcParser.If, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public If_tail_statementContext if_tail_statement() {
			return getRuleContext(If_tail_statementContext.class,0);
		}
		public If_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_if_statement; }
	}

	public final If_statementContext if_statement() throws RecognitionException {
		If_statementContext _localctx = new If_statementContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_if_statement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(180);
			match(If);
			setState(181);
			((If_statementContext)_localctx).cond = expression();
			setState(182);
			block();
			setState(184);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Else) {
				{
				setState(183);
				if_tail_statement();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class If_tail_statementContext extends ParserRuleContext {
		public BlockContext end_block;
		public If_statementContext elif;
		public TerminalNode Else() { return getToken(highcParser.Else, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public If_statementContext if_statement() {
			return getRuleContext(If_statementContext.class,0);
		}
		public If_tail_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_if_tail_statement; }
	}

	public final If_tail_statementContext if_tail_statement() throws RecognitionException {
		If_tail_statementContext _localctx = new If_tail_statementContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_if_tail_statement);
		try {
			setState(190);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(186);
				match(Else);
				setState(187);
				((If_tail_statementContext)_localctx).end_block = block();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(188);
				match(Else);
				setState(189);
				((If_tail_statementContext)_localctx).elif = if_statement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class While_statementContext extends ParserRuleContext {
		public ExpressionContext cond;
		public TerminalNode While() { return getToken(highcParser.While, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public While_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_while_statement; }
	}

	public final While_statementContext while_statement() throws RecognitionException {
		While_statementContext _localctx = new While_statementContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_while_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
			match(While);
			setState(193);
			((While_statementContext)_localctx).cond = expression();
			setState(194);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Assign_statementContext extends ParserRuleContext {
		public ExpressionContext target;
		public ExpressionContext value;
		public TerminalNode Equal() { return getToken(highcParser.Equal, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public Assign_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assign_statement; }
	}

	public final Assign_statementContext assign_statement() throws RecognitionException {
		Assign_statementContext _localctx = new Assign_statementContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_assign_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(196);
			((Assign_statementContext)_localctx).target = expression();
			setState(197);
			match(Equal);
			setState(198);
			((Assign_statementContext)_localctx).value = expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Let_expressionContext extends ParserRuleContext {
		public TerminalNode Uninit() { return getToken(highcParser.Uninit, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Let_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_let_expression; }
	}

	public final Let_expressionContext let_expression() throws RecognitionException {
		Let_expressionContext _localctx = new Let_expressionContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_let_expression);
		try {
			setState(202);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case Uninit:
				enterOuterAlt(_localctx, 1);
				{
				setState(200);
				match(Uninit);
				}
				break;
			case T__12:
			case New:
			case Not:
			case True:
			case False:
			case Identifier:
			case Integer:
			case Float:
			case String:
			case Plus:
			case Minus:
			case OpenParen:
				enterOuterAlt(_localctx, 2);
				{
				setState(201);
				expression();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Let_statementContext extends ParserRuleContext {
		public Token spec;
		public Token target;
		public TypenameContext type;
		public Let_expressionContext value;
		public TerminalNode Equal() { return getToken(highcParser.Equal, 0); }
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public Let_expressionContext let_expression() {
			return getRuleContext(Let_expressionContext.class,0);
		}
		public TerminalNode Let() { return getToken(highcParser.Let, 0); }
		public TerminalNode Var() { return getToken(highcParser.Var, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public Let_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_let_statement; }
	}

	public final Let_statementContext let_statement() throws RecognitionException {
		Let_statementContext _localctx = new Let_statementContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_let_statement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(204);
			((Let_statementContext)_localctx).spec = _input.LT(1);
			_la = _input.LA(1);
			if ( !(_la==Var || _la==Let) ) {
				((Let_statementContext)_localctx).spec = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(205);
			((Let_statementContext)_localctx).target = match(Identifier);
			setState(207);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
				{
				setState(206);
				((Let_statementContext)_localctx).type = typename(0);
				}
			}

			setState(209);
			match(Equal);
			setState(210);
			((Let_statementContext)_localctx).value = let_expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Typename_fn_argsContext extends ParserRuleContext {
		public TypenameContext type;
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public Typename_fn_argsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typename_fn_args; }
	}

	public final Typename_fn_argsContext typename_fn_args() throws RecognitionException {
		Typename_fn_argsContext _localctx = new Typename_fn_argsContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_typename_fn_args);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(213);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				{
				setState(212);
				match(Identifier);
				}
				break;
			}
			setState(215);
			((Typename_fn_argsContext)_localctx).type = typename(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypenameContext extends ParserRuleContext {
		public TypenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typename; }
	 
		public TypenameContext() { }
		public void copyFrom(TypenameContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenameManyContext extends TypenameContext {
		public Token Identifier;
		public List<Token> parts = new ArrayList<Token>();
		public List<TerminalNode> Identifier() { return getTokens(highcParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(highcParser.Identifier, i);
		}
		public TypenameManyContext(TypenameContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenameGenericContext extends TypenameContext {
		public TypenameContext base;
		public TypenameContext typename;
		public List<TypenameContext> args = new ArrayList<TypenameContext>();
		public List<TypenameContext> typename() {
			return getRuleContexts(TypenameContext.class);
		}
		public TypenameContext typename(int i) {
			return getRuleContext(TypenameContext.class,i);
		}
		public TypenameGenericContext(TypenameContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenameFnContext extends TypenameContext {
		public Typename_fn_argsContext typename_fn_args;
		public List<Typename_fn_argsContext> args = new ArrayList<Typename_fn_argsContext>();
		public TypenameContext ret;
		public TerminalNode Fn() { return getToken(highcParser.Fn, 0); }
		public TerminalNode OpenParen() { return getToken(highcParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(highcParser.CloseParen, 0); }
		public List<Typename_fn_argsContext> typename_fn_args() {
			return getRuleContexts(Typename_fn_argsContext.class);
		}
		public Typename_fn_argsContext typename_fn_args(int i) {
			return getRuleContext(Typename_fn_argsContext.class,i);
		}
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TypenameFnContext(TypenameContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenameArrayContext extends TypenameContext {
		public TypenameContext base;
		public Token count;
		public TerminalNode OpenIndex() { return getToken(highcParser.OpenIndex, 0); }
		public TerminalNode CloseIndex() { return getToken(highcParser.CloseIndex, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Integer() { return getToken(highcParser.Integer, 0); }
		public TypenameArrayContext(TypenameContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenameSingleContext extends TypenameContext {
		public TypenameContext inner;
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public TerminalNode OpenParen() { return getToken(highcParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(highcParser.CloseParen, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TypenameSingleContext(TypenameContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenamePointerContext extends TypenameContext {
		public TypenameContext base;
		public TerminalNode Star() { return getToken(highcParser.Star, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TypenamePointerContext(TypenameContext ctx) { copyFrom(ctx); }
	}

	public final TypenameContext typename() throws RecognitionException {
		return typename(0);
	}

	private TypenameContext typename(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TypenameContext _localctx = new TypenameContext(_ctx, _parentState);
		TypenameContext _prevctx = _localctx;
		int _startState = 42;
		enterRecursionRule(_localctx, 42, RULE_typename, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(256);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				{
				_localctx = new TypenameSingleContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(218);
				match(Identifier);
				}
				break;
			case 2:
				{
				_localctx = new TypenameSingleContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(219);
				match(OpenParen);
				setState(220);
				((TypenameSingleContext)_localctx).inner = typename(0);
				setState(221);
				match(CloseParen);
				}
				break;
			case 3:
				{
				_localctx = new TypenameManyContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(223);
				((TypenameManyContext)_localctx).Identifier = match(Identifier);
				((TypenameManyContext)_localctx).parts.add(((TypenameManyContext)_localctx).Identifier);
				setState(226); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(224);
						match(T__0);
						setState(225);
						((TypenameManyContext)_localctx).Identifier = match(Identifier);
						((TypenameManyContext)_localctx).parts.add(((TypenameManyContext)_localctx).Identifier);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(228); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			case 4:
				{
				_localctx = new TypenamePointerContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(230);
				match(Star);
				setState(231);
				((TypenamePointerContext)_localctx).base = typename(3);
				}
				break;
			case 5:
				{
				_localctx = new TypenameArrayContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(232);
				match(OpenIndex);
				setState(233);
				((TypenameArrayContext)_localctx).base = typename(0);
				setState(236);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__3) {
					{
					setState(234);
					match(T__3);
					setState(235);
					((TypenameArrayContext)_localctx).count = match(Integer);
					}
				}

				setState(238);
				match(CloseIndex);
				}
				break;
			case 6:
				{
				_localctx = new TypenameFnContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(240);
				match(Fn);
				setState(241);
				match(OpenParen);
				setState(250);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
					{
					setState(242);
					((TypenameFnContext)_localctx).typename_fn_args = typename_fn_args();
					((TypenameFnContext)_localctx).args.add(((TypenameFnContext)_localctx).typename_fn_args);
					setState(247);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==T__1) {
						{
						{
						setState(243);
						match(T__1);
						setState(244);
						((TypenameFnContext)_localctx).typename_fn_args = typename_fn_args();
						((TypenameFnContext)_localctx).args.add(((TypenameFnContext)_localctx).typename_fn_args);
						}
						}
						setState(249);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(252);
				match(CloseParen);
				setState(254);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,23,_ctx) ) {
				case 1:
					{
					setState(253);
					((TypenameFnContext)_localctx).ret = typename(0);
					}
					break;
				}
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(269);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,26,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TypenameGenericContext(new TypenameContext(_parentctx, _parentState));
					((TypenameGenericContext)_localctx).base = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_typename);
					setState(258);
					if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
					setState(259);
					match(T__2);
					setState(261); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(260);
						((TypenameGenericContext)_localctx).typename = typename(0);
						((TypenameGenericContext)_localctx).args.add(((TypenameGenericContext)_localctx).typename);
						}
						}
						setState(263); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0) );
					setState(265);
					match(T__2);
					}
					} 
				}
				setState(271);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,26,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionContext extends ParserRuleContext {
		public Op_expressionContext op_expression() {
			return getRuleContext(Op_expressionContext.class,0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	}

	public final ExpressionContext expression() throws RecognitionException {
		ExpressionContext _localctx = new ExpressionContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(272);
			op_expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Op_expressionContext extends ParserRuleContext {
		public Op_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_op_expression; }
	 
		public Op_expressionContext() { }
		public void copyFrom(Op_expressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AddExpressionContext extends Op_expressionContext {
		public Op_expressionContext rhs;
		public List<Op_expressionContext> op_expression() {
			return getRuleContexts(Op_expressionContext.class);
		}
		public Op_expressionContext op_expression(int i) {
			return getRuleContext(Op_expressionContext.class,i);
		}
		public TerminalNode Plus() { return getToken(highcParser.Plus, 0); }
		public TerminalNode Minus() { return getToken(highcParser.Minus, 0); }
		public AddExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LogicExpressionContext extends Op_expressionContext {
		public Op_expressionContext lhs;
		public List<Op_expressionContext> op_expression() {
			return getRuleContexts(Op_expressionContext.class);
		}
		public Op_expressionContext op_expression(int i) {
			return getRuleContext(Op_expressionContext.class,i);
		}
		public TerminalNode And() { return getToken(highcParser.And, 0); }
		public TerminalNode Or() { return getToken(highcParser.Or, 0); }
		public LogicExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MemoryExpressionContext extends Op_expressionContext {
		public Op_expressionContext op;
		public Op_expressionContext op_expression() {
			return getRuleContext(Op_expressionContext.class,0);
		}
		public TerminalNode Star() { return getToken(highcParser.Star, 0); }
		public TerminalNode Ampersand() { return getToken(highcParser.Ampersand, 0); }
		public MemoryExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class UnaryExpressionContext extends Op_expressionContext {
		public Op_expressionContext op;
		public TerminalNode Plus() { return getToken(highcParser.Plus, 0); }
		public TerminalNode Minus() { return getToken(highcParser.Minus, 0); }
		public TerminalNode Not() { return getToken(highcParser.Not, 0); }
		public Op_expressionContext op_expression() {
			return getRuleContext(Op_expressionContext.class,0);
		}
		public UnaryExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CompareExpressionContext extends Op_expressionContext {
		public Op_expressionContext lhs;
		public List<Op_expressionContext> op_expression() {
			return getRuleContexts(Op_expressionContext.class);
		}
		public Op_expressionContext op_expression(int i) {
			return getRuleContext(Op_expressionContext.class,i);
		}
		public TerminalNode CompEqual() { return getToken(highcParser.CompEqual, 0); }
		public CompareExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CallExpressionContext extends Op_expressionContext {
		public Call_expressionContext call_expression() {
			return getRuleContext(Call_expressionContext.class,0);
		}
		public CallExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MulExpressionContext extends Op_expressionContext {
		public Op_expressionContext lhs;
		public List<Op_expressionContext> op_expression() {
			return getRuleContexts(Op_expressionContext.class);
		}
		public Op_expressionContext op_expression(int i) {
			return getRuleContext(Op_expressionContext.class,i);
		}
		public TerminalNode Star() { return getToken(highcParser.Star, 0); }
		public TerminalNode Slash() { return getToken(highcParser.Slash, 0); }
		public MulExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class BitwiseExpressionContext extends Op_expressionContext {
		public Op_expressionContext rhs;
		public List<Op_expressionContext> op_expression() {
			return getRuleContexts(Op_expressionContext.class);
		}
		public Op_expressionContext op_expression(int i) {
			return getRuleContext(Op_expressionContext.class,i);
		}
		public TerminalNode Ampersand() { return getToken(highcParser.Ampersand, 0); }
		public BitwiseExpressionContext(Op_expressionContext ctx) { copyFrom(ctx); }
	}

	public final Op_expressionContext op_expression() throws RecognitionException {
		return op_expression(0);
	}

	private Op_expressionContext op_expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Op_expressionContext _localctx = new Op_expressionContext(_ctx, _parentState);
		Op_expressionContext _prevctx = _localctx;
		int _startState = 46;
		enterRecursionRule(_localctx, 46, RULE_op_expression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(278);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__12:
			case Not:
			case Plus:
			case Minus:
				{
				_localctx = new UnaryExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(275);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 105621835751424L) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(276);
				((UnaryExpressionContext)_localctx).op = op_expression(3);
				}
				break;
			case New:
			case True:
			case False:
			case Identifier:
			case Integer:
			case Float:
			case String:
			case OpenParen:
				{
				_localctx = new CallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(277);
				call_expression(0);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(299);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,29,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(297);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,28,_ctx) ) {
					case 1:
						{
						_localctx = new LogicExpressionContext(new Op_expressionContext(_parentctx, _parentState));
						((LogicExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_op_expression);
						setState(280);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(281);
						_la = _input.LA(1);
						if ( !(_la==And || _la==Or) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(282);
						((LogicExpressionContext)_localctx).lhs = op_expression(9);
						}
						break;
					case 2:
						{
						_localctx = new CompareExpressionContext(new Op_expressionContext(_parentctx, _parentState));
						((CompareExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_op_expression);
						setState(283);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(284);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 2251799813686240L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(285);
						((CompareExpressionContext)_localctx).lhs = op_expression(8);
						}
						break;
					case 3:
						{
						_localctx = new MulExpressionContext(new Op_expressionContext(_parentctx, _parentState));
						((MulExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_op_expression);
						setState(286);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(287);
						_la = _input.LA(1);
						if ( !(_la==Star || _la==Slash) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(288);
						((MulExpressionContext)_localctx).lhs = op_expression(7);
						}
						break;
					case 4:
						{
						_localctx = new BitwiseExpressionContext(new Op_expressionContext(_parentctx, _parentState));
						((BitwiseExpressionContext)_localctx).rhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_op_expression);
						setState(289);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(290);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 562949953428480L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(291);
						((BitwiseExpressionContext)_localctx).rhs = op_expression(6);
						}
						break;
					case 5:
						{
						_localctx = new AddExpressionContext(new Op_expressionContext(_parentctx, _parentState));
						((AddExpressionContext)_localctx).rhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_op_expression);
						setState(292);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(293);
						_la = _input.LA(1);
						if ( !(_la==Plus || _la==Minus) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(294);
						((AddExpressionContext)_localctx).rhs = op_expression(5);
						}
						break;
					case 6:
						{
						_localctx = new MemoryExpressionContext(new Op_expressionContext(_parentctx, _parentState));
						((MemoryExpressionContext)_localctx).op = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_op_expression);
						setState(295);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(296);
						_la = _input.LA(1);
						if ( !(_la==Star || _la==Ampersand) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						}
						break;
					}
					} 
				}
				setState(301);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,29,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Explicit_template_instantiationContext extends ParserRuleContext {
		public TypenameContext typename;
		public List<TypenameContext> args = new ArrayList<TypenameContext>();
		public List<TypenameContext> typename() {
			return getRuleContexts(TypenameContext.class);
		}
		public TypenameContext typename(int i) {
			return getRuleContext(TypenameContext.class,i);
		}
		public Explicit_template_instantiationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_explicit_template_instantiation; }
	}

	public final Explicit_template_instantiationContext explicit_template_instantiation() throws RecognitionException {
		Explicit_template_instantiationContext _localctx = new Explicit_template_instantiationContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_explicit_template_instantiation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(302);
			match(T__2);
			setState(306);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
				{
				{
				setState(303);
				((Explicit_template_instantiationContext)_localctx).typename = typename(0);
				((Explicit_template_instantiationContext)_localctx).args.add(((Explicit_template_instantiationContext)_localctx).typename);
				}
				}
				setState(308);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(309);
			match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Call_expressionContext extends ParserRuleContext {
		public Call_expressionContext target;
		public Explicit_template_instantiationContext inst;
		public ExpressionContext expression;
		public List<ExpressionContext> args = new ArrayList<ExpressionContext>();
		public Dot_expressionContext dot_expression() {
			return getRuleContext(Dot_expressionContext.class,0);
		}
		public TerminalNode OpenParen() { return getToken(highcParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(highcParser.CloseParen, 0); }
		public Call_expressionContext call_expression() {
			return getRuleContext(Call_expressionContext.class,0);
		}
		public Explicit_template_instantiationContext explicit_template_instantiation() {
			return getRuleContext(Explicit_template_instantiationContext.class,0);
		}
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public Call_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_call_expression; }
	}

	public final Call_expressionContext call_expression() throws RecognitionException {
		return call_expression(0);
	}

	private Call_expressionContext call_expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Call_expressionContext _localctx = new Call_expressionContext(_ctx, _parentState);
		Call_expressionContext _prevctx = _localctx;
		int _startState = 50;
		enterRecursionRule(_localctx, 50, RULE_call_expression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(312);
			dot_expression(0);
			}
			_ctx.stop = _input.LT(-1);
			setState(332);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,34,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new Call_expressionContext(_parentctx, _parentState);
					_localctx.target = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_call_expression);
					setState(314);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(316);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==T__2) {
						{
						setState(315);
						((Call_expressionContext)_localctx).inst = explicit_template_instantiation();
						}
					}

					setState(318);
					match(OpenParen);
					setState(327);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4643031982546944L) != 0)) {
						{
						setState(319);
						((Call_expressionContext)_localctx).expression = expression();
						((Call_expressionContext)_localctx).args.add(((Call_expressionContext)_localctx).expression);
						setState(324);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==T__1) {
							{
							{
							setState(320);
							match(T__1);
							setState(321);
							((Call_expressionContext)_localctx).expression = expression();
							((Call_expressionContext)_localctx).args.add(((Call_expressionContext)_localctx).expression);
							}
							}
							setState(326);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						}
					}

					setState(329);
					match(CloseParen);
					}
					} 
				}
				setState(334);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,34,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Struct_expressionContext extends ParserRuleContext {
		public Struct_expression_setContext struct_expression_set;
		public List<Struct_expression_setContext> parts = new ArrayList<Struct_expression_setContext>();
		public TerminalNode New() { return getToken(highcParser.New, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode OpenBrace() { return getToken(highcParser.OpenBrace, 0); }
		public TerminalNode CloseBrace() { return getToken(highcParser.CloseBrace, 0); }
		public List<Struct_expression_setContext> struct_expression_set() {
			return getRuleContexts(Struct_expression_setContext.class);
		}
		public Struct_expression_setContext struct_expression_set(int i) {
			return getRuleContext(Struct_expression_setContext.class,i);
		}
		public Struct_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_struct_expression; }
	}

	public final Struct_expressionContext struct_expression() throws RecognitionException {
		Struct_expressionContext _localctx = new Struct_expressionContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_struct_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(335);
			match(New);
			setState(336);
			typename(0);
			setState(337);
			match(OpenBrace);
			setState(339); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(338);
				((Struct_expressionContext)_localctx).struct_expression_set = struct_expression_set();
				((Struct_expressionContext)_localctx).parts.add(((Struct_expressionContext)_localctx).struct_expression_set);
				}
				}
				setState(341); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==Let );
			setState(343);
			match(CloseBrace);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Struct_expression_setContext extends ParserRuleContext {
		public TerminalNode Let() { return getToken(highcParser.Let, 0); }
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public TerminalNode Equal() { return getToken(highcParser.Equal, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Struct_expression_setContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_struct_expression_set; }
	}

	public final Struct_expression_setContext struct_expression_set() throws RecognitionException {
		Struct_expression_setContext _localctx = new Struct_expression_setContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_struct_expression_set);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(345);
			match(Let);
			setState(346);
			match(Identifier);
			setState(347);
			match(Equal);
			setState(348);
			expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Dot_expressionContext extends ParserRuleContext {
		public Token field;
		public Term_expressionContext term_expression() {
			return getRuleContext(Term_expressionContext.class,0);
		}
		public Dot_expressionContext dot_expression() {
			return getRuleContext(Dot_expressionContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public Dot_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_dot_expression; }
	}

	public final Dot_expressionContext dot_expression() throws RecognitionException {
		return dot_expression(0);
	}

	private Dot_expressionContext dot_expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Dot_expressionContext _localctx = new Dot_expressionContext(_ctx, _parentState);
		Dot_expressionContext _prevctx = _localctx;
		int _startState = 56;
		enterRecursionRule(_localctx, 56, RULE_dot_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(351);
			term_expression();
			}
			_ctx.stop = _input.LT(-1);
			setState(358);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new Dot_expressionContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_dot_expression);
					setState(353);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(354);
					match(T__0);
					setState(355);
					((Dot_expressionContext)_localctx).field = match(Identifier);
					}
					} 
				}
				setState(360);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Term_expressionContext extends ParserRuleContext {
		public LiteralContext literal() {
			return getRuleContext(LiteralContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(highcParser.Identifier, 0); }
		public TerminalNode OpenParen() { return getToken(highcParser.OpenParen, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode CloseParen() { return getToken(highcParser.CloseParen, 0); }
		public Struct_expressionContext struct_expression() {
			return getRuleContext(Struct_expressionContext.class,0);
		}
		public Term_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_term_expression; }
	}

	public final Term_expressionContext term_expression() throws RecognitionException {
		Term_expressionContext _localctx = new Term_expressionContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_term_expression);
		try {
			setState(368);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case True:
			case False:
			case Integer:
			case Float:
			case String:
				enterOuterAlt(_localctx, 1);
				{
				setState(361);
				literal();
				}
				break;
			case Identifier:
				enterOuterAlt(_localctx, 2);
				{
				setState(362);
				match(Identifier);
				}
				break;
			case OpenParen:
				enterOuterAlt(_localctx, 3);
				{
				setState(363);
				match(OpenParen);
				setState(364);
				expression();
				setState(365);
				match(CloseParen);
				}
				break;
			case New:
				enterOuterAlt(_localctx, 4);
				{
				setState(367);
				struct_expression();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LiteralContext extends ParserRuleContext {
		public TerminalNode Integer() { return getToken(highcParser.Integer, 0); }
		public TerminalNode Float() { return getToken(highcParser.Float, 0); }
		public TerminalNode String() { return getToken(highcParser.String, 0); }
		public Boolean_literalContext boolean_literal() {
			return getRuleContext(Boolean_literalContext.class,0);
		}
		public LiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal; }
	}

	public final LiteralContext literal() throws RecognitionException {
		LiteralContext _localctx = new LiteralContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_literal);
		try {
			setState(374);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case Integer:
				enterOuterAlt(_localctx, 1);
				{
				setState(370);
				match(Integer);
				}
				break;
			case Float:
				enterOuterAlt(_localctx, 2);
				{
				setState(371);
				match(Float);
				}
				break;
			case String:
				enterOuterAlt(_localctx, 3);
				{
				setState(372);
				match(String);
				}
				break;
			case True:
			case False:
				enterOuterAlt(_localctx, 4);
				{
				setState(373);
				boolean_literal();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Boolean_literalContext extends ParserRuleContext {
		public TerminalNode True() { return getToken(highcParser.True, 0); }
		public TerminalNode False() { return getToken(highcParser.False, 0); }
		public Boolean_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean_literal; }
	}

	public final Boolean_literalContext boolean_literal() throws RecognitionException {
		Boolean_literalContext _localctx = new Boolean_literalContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_boolean_literal);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(376);
			_la = _input.LA(1);
			if ( !(_la==True || _la==False) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 21:
			return typename_sempred((TypenameContext)_localctx, predIndex);
		case 23:
			return op_expression_sempred((Op_expressionContext)_localctx, predIndex);
		case 25:
			return call_expression_sempred((Call_expressionContext)_localctx, predIndex);
		case 28:
			return dot_expression_sempred((Dot_expressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean typename_sempred(TypenameContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 4);
		}
		return true;
	}
	private boolean op_expression_sempred(Op_expressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 8);
		case 2:
			return precpred(_ctx, 7);
		case 3:
			return precpred(_ctx, 6);
		case 4:
			return precpred(_ctx, 5);
		case 5:
			return precpred(_ctx, 4);
		case 6:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean call_expression_sempred(Call_expressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 7:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean dot_expression_sempred(Dot_expressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 8:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u00019\u017b\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0001\u0000\u0005\u0000B\b\u0000\n\u0000\f\u0000"+
		"E\t\u0000\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001"+
		"\u0001\u0001\u0003\u0001M\b\u0001\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0001\u0002\u0005\u0002S\b\u0002\n\u0002\f\u0002V\t\u0002\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0005\u0003\\\b\u0003\n\u0003\f\u0003"+
		"_\t\u0003\u0001\u0004\u0001\u0004\u0004\u0004c\b\u0004\u000b\u0004\f\u0004"+
		"d\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0003\u0006"+
		"l\b\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0005\u0006"+
		"r\b\u0006\n\u0006\f\u0006u\t\u0006\u0001\u0006\u0001\u0006\u0001\u0007"+
		"\u0003\u0007z\b\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\b\u0003"+
		"\b\u0080\b\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0005\b\u0088"+
		"\b\b\n\b\f\b\u008b\t\b\u0003\b\u008d\b\b\u0001\b\u0001\b\u0003\b\u0091"+
		"\b\b\u0001\b\u0001\b\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\n\u0001"+
		"\n\u0005\n\u009c\b\n\n\n\f\n\u009f\t\n\u0001\n\u0001\n\u0001\u000b\u0001"+
		"\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001"+
		"\u000b\u0001\u000b\u0001\u000b\u0003\u000b\u00ad\b\u000b\u0001\f\u0001"+
		"\f\u0001\f\u0001\r\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000e"+
		"\u0001\u000e\u0003\u000e\u00b9\b\u000e\u0001\u000f\u0001\u000f\u0001\u000f"+
		"\u0001\u000f\u0003\u000f\u00bf\b\u000f\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0012"+
		"\u0001\u0012\u0003\u0012\u00cb\b\u0012\u0001\u0013\u0001\u0013\u0001\u0013"+
		"\u0003\u0013\u00d0\b\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0014"+
		"\u0003\u0014\u00d6\b\u0014\u0001\u0014\u0001\u0014\u0001\u0015\u0001\u0015"+
		"\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015"+
		"\u0001\u0015\u0004\u0015\u00e3\b\u0015\u000b\u0015\f\u0015\u00e4\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0003"+
		"\u0015\u00ed\b\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0005\u0015\u00f6\b\u0015\n\u0015\f\u0015"+
		"\u00f9\t\u0015\u0003\u0015\u00fb\b\u0015\u0001\u0015\u0001\u0015\u0003"+
		"\u0015\u00ff\b\u0015\u0003\u0015\u0101\b\u0015\u0001\u0015\u0001\u0015"+
		"\u0001\u0015\u0004\u0015\u0106\b\u0015\u000b\u0015\f\u0015\u0107\u0001"+
		"\u0015\u0001\u0015\u0005\u0015\u010c\b\u0015\n\u0015\f\u0015\u010f\t\u0015"+
		"\u0001\u0016\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017"+
		"\u0003\u0017\u0117\b\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017"+
		"\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017"+
		"\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017"+
		"\u0001\u0017\u0005\u0017\u012a\b\u0017\n\u0017\f\u0017\u012d\t\u0017\u0001"+
		"\u0018\u0001\u0018\u0005\u0018\u0131\b\u0018\n\u0018\f\u0018\u0134\t\u0018"+
		"\u0001\u0018\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019"+
		"\u0001\u0019\u0003\u0019\u013d\b\u0019\u0001\u0019\u0001\u0019\u0001\u0019"+
		"\u0001\u0019\u0005\u0019\u0143\b\u0019\n\u0019\f\u0019\u0146\t\u0019\u0003"+
		"\u0019\u0148\b\u0019\u0001\u0019\u0005\u0019\u014b\b\u0019\n\u0019\f\u0019"+
		"\u014e\t\u0019\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0004\u001a"+
		"\u0154\b\u001a\u000b\u001a\f\u001a\u0155\u0001\u001a\u0001\u001a\u0001"+
		"\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001c\u0001"+
		"\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0005\u001c\u0165"+
		"\b\u001c\n\u001c\f\u001c\u0168\t\u001c\u0001\u001d\u0001\u001d\u0001\u001d"+
		"\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0003\u001d\u0171\b\u001d"+
		"\u0001\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0003\u001e\u0177\b\u001e"+
		"\u0001\u001f\u0001\u001f\u0001\u001f\u0000\u0004*.28 \u0000\u0002\u0004"+
		"\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e \""+
		"$&(*,.02468:<>\u0000\t\u0001\u0000\u0011\u0012\u0003\u0000\r\r$$-.\u0002"+
		"\u0000##%%\u0002\u0000\u0005\t33\u0001\u0000/0\u0002\u0000\n\f11\u0001"+
		"\u0000-.\u0002\u0000//11\u0001\u0000&\'\u0199\u0000C\u0001\u0000\u0000"+
		"\u0000\u0002L\u0001\u0000\u0000\u0000\u0004N\u0001\u0000\u0000\u0000\u0006"+
		"W\u0001\u0000\u0000\u0000\b`\u0001\u0000\u0000\u0000\nf\u0001\u0000\u0000"+
		"\u0000\fk\u0001\u0000\u0000\u0000\u000ey\u0001\u0000\u0000\u0000\u0010"+
		"\u007f\u0001\u0000\u0000\u0000\u0012\u0094\u0001\u0000\u0000\u0000\u0014"+
		"\u0099\u0001\u0000\u0000\u0000\u0016\u00ac\u0001\u0000\u0000\u0000\u0018"+
		"\u00ae\u0001\u0000\u0000\u0000\u001a\u00b1\u0001\u0000\u0000\u0000\u001c"+
		"\u00b4\u0001\u0000\u0000\u0000\u001e\u00be\u0001\u0000\u0000\u0000 \u00c0"+
		"\u0001\u0000\u0000\u0000\"\u00c4\u0001\u0000\u0000\u0000$\u00ca\u0001"+
		"\u0000\u0000\u0000&\u00cc\u0001\u0000\u0000\u0000(\u00d5\u0001\u0000\u0000"+
		"\u0000*\u0100\u0001\u0000\u0000\u0000,\u0110\u0001\u0000\u0000\u0000."+
		"\u0116\u0001\u0000\u0000\u00000\u012e\u0001\u0000\u0000\u00002\u0137\u0001"+
		"\u0000\u0000\u00004\u014f\u0001\u0000\u0000\u00006\u0159\u0001\u0000\u0000"+
		"\u00008\u015e\u0001\u0000\u0000\u0000:\u0170\u0001\u0000\u0000\u0000<"+
		"\u0176\u0001\u0000\u0000\u0000>\u0178\u0001\u0000\u0000\u0000@B\u0003"+
		"\u0002\u0001\u0000A@\u0001\u0000\u0000\u0000BE\u0001\u0000\u0000\u0000"+
		"CA\u0001\u0000\u0000\u0000CD\u0001\u0000\u0000\u0000D\u0001\u0001\u0000"+
		"\u0000\u0000EC\u0001\u0000\u0000\u0000FM\u0003\u0010\b\u0000GM\u0003\f"+
		"\u0006\u0000HM\u0003\u0012\t\u0000IM\u0003&\u0013\u0000JM\u0003\u0004"+
		"\u0002\u0000KM\u0003\u0006\u0003\u0000LF\u0001\u0000\u0000\u0000LG\u0001"+
		"\u0000\u0000\u0000LH\u0001\u0000\u0000\u0000LI\u0001\u0000\u0000\u0000"+
		"LJ\u0001\u0000\u0000\u0000LK\u0001\u0000\u0000\u0000M\u0003\u0001\u0000"+
		"\u0000\u0000NO\u0005 \u0000\u0000OT\u0005)\u0000\u0000PQ\u0005\u0001\u0000"+
		"\u0000QS\u0005)\u0000\u0000RP\u0001\u0000\u0000\u0000SV\u0001\u0000\u0000"+
		"\u0000TR\u0001\u0000\u0000\u0000TU\u0001\u0000\u0000\u0000U\u0005\u0001"+
		"\u0000\u0000\u0000VT\u0001\u0000\u0000\u0000WX\u0005!\u0000\u0000X]\u0005"+
		")\u0000\u0000YZ\u0005\u0001\u0000\u0000Z\\\u0005)\u0000\u0000[Y\u0001"+
		"\u0000\u0000\u0000\\_\u0001\u0000\u0000\u0000][\u0001\u0000\u0000\u0000"+
		"]^\u0001\u0000\u0000\u0000^\u0007\u0001\u0000\u0000\u0000_]\u0001\u0000"+
		"\u0000\u0000`b\u0005\u001c\u0000\u0000ac\u0005)\u0000\u0000ba\u0001\u0000"+
		"\u0000\u0000cd\u0001\u0000\u0000\u0000db\u0001\u0000\u0000\u0000de\u0001"+
		"\u0000\u0000\u0000e\t\u0001\u0000\u0000\u0000fg\u0005\u0012\u0000\u0000"+
		"gh\u0005)\u0000\u0000hi\u0003*\u0015\u0000i\u000b\u0001\u0000\u0000\u0000"+
		"jl\u0003\b\u0004\u0000kj\u0001\u0000\u0000\u0000kl\u0001\u0000\u0000\u0000"+
		"lm\u0001\u0000\u0000\u0000mn\u0005\u001b\u0000\u0000no\u0005)\u0000\u0000"+
		"os\u00056\u0000\u0000pr\u0003\n\u0005\u0000qp\u0001\u0000\u0000\u0000"+
		"ru\u0001\u0000\u0000\u0000sq\u0001\u0000\u0000\u0000st\u0001\u0000\u0000"+
		"\u0000tv\u0001\u0000\u0000\u0000us\u0001\u0000\u0000\u0000vw\u00057\u0000"+
		"\u0000w\r\u0001\u0000\u0000\u0000xz\u0005\"\u0000\u0000yx\u0001\u0000"+
		"\u0000\u0000yz\u0001\u0000\u0000\u0000z{\u0001\u0000\u0000\u0000{|\u0005"+
		")\u0000\u0000|}\u0003*\u0015\u0000}\u000f\u0001\u0000\u0000\u0000~\u0080"+
		"\u0003\b\u0004\u0000\u007f~\u0001\u0000\u0000\u0000\u007f\u0080\u0001"+
		"\u0000\u0000\u0000\u0080\u0081\u0001\u0000\u0000\u0000\u0081\u0082\u0005"+
		"\u0016\u0000\u0000\u0082\u0083\u0005)\u0000\u0000\u0083\u008c\u00054\u0000"+
		"\u0000\u0084\u0089\u0003\u000e\u0007\u0000\u0085\u0086\u0005\u0002\u0000"+
		"\u0000\u0086\u0088\u0003\u000e\u0007\u0000\u0087\u0085\u0001\u0000\u0000"+
		"\u0000\u0088\u008b\u0001\u0000\u0000\u0000\u0089\u0087\u0001\u0000\u0000"+
		"\u0000\u0089\u008a\u0001\u0000\u0000\u0000\u008a\u008d\u0001\u0000\u0000"+
		"\u0000\u008b\u0089\u0001\u0000\u0000\u0000\u008c\u0084\u0001\u0000\u0000"+
		"\u0000\u008c\u008d\u0001\u0000\u0000\u0000\u008d\u008e\u0001\u0000\u0000"+
		"\u0000\u008e\u0090\u00055\u0000\u0000\u008f\u0091\u0003*\u0015\u0000\u0090"+
		"\u008f\u0001\u0000\u0000\u0000\u0090\u0091\u0001\u0000\u0000\u0000\u0091"+
		"\u0092\u0001\u0000\u0000\u0000\u0092\u0093\u0003\u0014\n\u0000\u0093\u0011"+
		"\u0001\u0000\u0000\u0000\u0094\u0095\u0005\u001a\u0000\u0000\u0095\u0096"+
		"\u0005)\u0000\u0000\u0096\u0097\u00052\u0000\u0000\u0097\u0098\u0003*"+
		"\u0015\u0000\u0098\u0013\u0001\u0000\u0000\u0000\u0099\u009d\u00056\u0000"+
		"\u0000\u009a\u009c\u0003\u0016\u000b\u0000\u009b\u009a\u0001\u0000\u0000"+
		"\u0000\u009c\u009f\u0001\u0000\u0000\u0000\u009d\u009b\u0001\u0000\u0000"+
		"\u0000\u009d\u009e\u0001\u0000\u0000\u0000\u009e\u00a0\u0001\u0000\u0000"+
		"\u0000\u009f\u009d\u0001\u0000\u0000\u0000\u00a0\u00a1\u00057\u0000\u0000"+
		"\u00a1\u0015\u0001\u0000\u0000\u0000\u00a2\u00ad\u0003\"\u0011\u0000\u00a3"+
		"\u00ad\u0003&\u0013\u0000\u00a4\u00ad\u0003\u001c\u000e\u0000\u00a5\u00ad"+
		"\u0003 \u0010\u0000\u00a6\u00ad\u0003\u001a\r\u0000\u00a7\u00ad\u0003"+
		"\u0018\f\u0000\u00a8\u00ad\u0005\u0017\u0000\u0000\u00a9\u00ad\u0005\u0018"+
		"\u0000\u0000\u00aa\u00ad\u0003\u0014\n\u0000\u00ab\u00ad\u0003,\u0016"+
		"\u0000\u00ac\u00a2\u0001\u0000\u0000\u0000\u00ac\u00a3\u0001\u0000\u0000"+
		"\u0000\u00ac\u00a4\u0001\u0000\u0000\u0000\u00ac\u00a5\u0001\u0000\u0000"+
		"\u0000\u00ac\u00a6\u0001\u0000\u0000\u0000\u00ac\u00a7\u0001\u0000\u0000"+
		"\u0000\u00ac\u00a8\u0001\u0000\u0000\u0000\u00ac\u00a9\u0001\u0000\u0000"+
		"\u0000\u00ac\u00aa\u0001\u0000\u0000\u0000\u00ac\u00ab\u0001\u0000\u0000"+
		"\u0000\u00ad\u0017\u0001\u0000\u0000\u0000\u00ae\u00af\u0005\u001e\u0000"+
		"\u0000\u00af\u00b0\u0003,\u0016\u0000\u00b0\u0019\u0001\u0000\u0000\u0000"+
		"\u00b1\u00b2\u0005\u0019\u0000\u0000\u00b2\u00b3\u0003\u0014\n\u0000\u00b3"+
		"\u001b\u0001\u0000\u0000\u0000\u00b4\u00b5\u0005\u0013\u0000\u0000\u00b5"+
		"\u00b6\u0003,\u0016\u0000\u00b6\u00b8\u0003\u0014\n\u0000\u00b7\u00b9"+
		"\u0003\u001e\u000f\u0000\u00b8\u00b7\u0001\u0000\u0000\u0000\u00b8\u00b9"+
		"\u0001\u0000\u0000\u0000\u00b9\u001d\u0001\u0000\u0000\u0000\u00ba\u00bb"+
		"\u0005\u0014\u0000\u0000\u00bb\u00bf\u0003\u0014\n\u0000\u00bc\u00bd\u0005"+
		"\u0014\u0000\u0000\u00bd\u00bf\u0003\u001c\u000e\u0000\u00be\u00ba\u0001"+
		"\u0000\u0000\u0000\u00be\u00bc\u0001\u0000\u0000\u0000\u00bf\u001f\u0001"+
		"\u0000\u0000\u0000\u00c0\u00c1\u0005\u0015\u0000\u0000\u00c1\u00c2\u0003"+
		",\u0016\u0000\u00c2\u00c3\u0003\u0014\n\u0000\u00c3!\u0001\u0000\u0000"+
		"\u0000\u00c4\u00c5\u0003,\u0016\u0000\u00c5\u00c6\u00052\u0000\u0000\u00c6"+
		"\u00c7\u0003,\u0016\u0000\u00c7#\u0001\u0000\u0000\u0000\u00c8\u00cb\u0005"+
		"(\u0000\u0000\u00c9\u00cb\u0003,\u0016\u0000\u00ca\u00c8\u0001\u0000\u0000"+
		"\u0000\u00ca\u00c9\u0001\u0000\u0000\u0000\u00cb%\u0001\u0000\u0000\u0000"+
		"\u00cc\u00cd\u0007\u0000\u0000\u0000\u00cd\u00cf\u0005)\u0000\u0000\u00ce"+
		"\u00d0\u0003*\u0015\u0000\u00cf\u00ce\u0001\u0000\u0000\u0000\u00cf\u00d0"+
		"\u0001\u0000\u0000\u0000\u00d0\u00d1\u0001\u0000\u0000\u0000\u00d1\u00d2"+
		"\u00052\u0000\u0000\u00d2\u00d3\u0003$\u0012\u0000\u00d3\'\u0001\u0000"+
		"\u0000\u0000\u00d4\u00d6\u0005)\u0000\u0000\u00d5\u00d4\u0001\u0000\u0000"+
		"\u0000\u00d5\u00d6\u0001\u0000\u0000\u0000\u00d6\u00d7\u0001\u0000\u0000"+
		"\u0000\u00d7\u00d8\u0003*\u0015\u0000\u00d8)\u0001\u0000\u0000\u0000\u00d9"+
		"\u00da\u0006\u0015\uffff\uffff\u0000\u00da\u0101\u0005)\u0000\u0000\u00db"+
		"\u00dc\u00054\u0000\u0000\u00dc\u00dd\u0003*\u0015\u0000\u00dd\u00de\u0005"+
		"5\u0000\u0000\u00de\u0101\u0001\u0000\u0000\u0000\u00df\u00e2\u0005)\u0000"+
		"\u0000\u00e0\u00e1\u0005\u0001\u0000\u0000\u00e1\u00e3\u0005)\u0000\u0000"+
		"\u00e2\u00e0\u0001\u0000\u0000\u0000\u00e3\u00e4\u0001\u0000\u0000\u0000"+
		"\u00e4\u00e2\u0001\u0000\u0000\u0000\u00e4\u00e5\u0001\u0000\u0000\u0000"+
		"\u00e5\u0101\u0001\u0000\u0000\u0000\u00e6\u00e7\u0005/\u0000\u0000\u00e7"+
		"\u0101\u0003*\u0015\u0003\u00e8\u00e9\u00058\u0000\u0000\u00e9\u00ec\u0003"+
		"*\u0015\u0000\u00ea\u00eb\u0005\u0004\u0000\u0000\u00eb\u00ed\u0005*\u0000"+
		"\u0000\u00ec\u00ea\u0001\u0000\u0000\u0000\u00ec\u00ed\u0001\u0000\u0000"+
		"\u0000\u00ed\u00ee\u0001\u0000\u0000\u0000\u00ee\u00ef\u00059\u0000\u0000"+
		"\u00ef\u0101\u0001\u0000\u0000\u0000\u00f0\u00f1\u0005\u0016\u0000\u0000"+
		"\u00f1\u00fa\u00054\u0000\u0000\u00f2\u00f7\u0003(\u0014\u0000\u00f3\u00f4"+
		"\u0005\u0002\u0000\u0000\u00f4\u00f6\u0003(\u0014\u0000\u00f5\u00f3\u0001"+
		"\u0000\u0000\u0000\u00f6\u00f9\u0001\u0000\u0000\u0000\u00f7\u00f5\u0001"+
		"\u0000\u0000\u0000\u00f7\u00f8\u0001\u0000\u0000\u0000\u00f8\u00fb\u0001"+
		"\u0000\u0000\u0000\u00f9\u00f7\u0001\u0000\u0000\u0000\u00fa\u00f2\u0001"+
		"\u0000\u0000\u0000\u00fa\u00fb\u0001\u0000\u0000\u0000\u00fb\u00fc\u0001"+
		"\u0000\u0000\u0000\u00fc\u00fe\u00055\u0000\u0000\u00fd\u00ff\u0003*\u0015"+
		"\u0000\u00fe\u00fd\u0001\u0000\u0000\u0000\u00fe\u00ff\u0001\u0000\u0000"+
		"\u0000\u00ff\u0101\u0001\u0000\u0000\u0000\u0100\u00d9\u0001\u0000\u0000"+
		"\u0000\u0100\u00db\u0001\u0000\u0000\u0000\u0100\u00df\u0001\u0000\u0000"+
		"\u0000\u0100\u00e6\u0001\u0000\u0000\u0000\u0100\u00e8\u0001\u0000\u0000"+
		"\u0000\u0100\u00f0\u0001\u0000\u0000\u0000\u0101\u010d\u0001\u0000\u0000"+
		"\u0000\u0102\u0103\n\u0004\u0000\u0000\u0103\u0105\u0005\u0003\u0000\u0000"+
		"\u0104\u0106\u0003*\u0015\u0000\u0105\u0104\u0001\u0000\u0000\u0000\u0106"+
		"\u0107\u0001\u0000\u0000\u0000\u0107\u0105\u0001\u0000\u0000\u0000\u0107"+
		"\u0108\u0001\u0000\u0000\u0000\u0108\u0109\u0001\u0000\u0000\u0000\u0109"+
		"\u010a\u0005\u0003\u0000\u0000\u010a\u010c\u0001\u0000\u0000\u0000\u010b"+
		"\u0102\u0001\u0000\u0000\u0000\u010c\u010f\u0001\u0000\u0000\u0000\u010d"+
		"\u010b\u0001\u0000\u0000\u0000\u010d\u010e\u0001\u0000\u0000\u0000\u010e"+
		"+\u0001\u0000\u0000\u0000\u010f\u010d\u0001\u0000\u0000\u0000\u0110\u0111"+
		"\u0003.\u0017\u0000\u0111-\u0001\u0000\u0000\u0000\u0112\u0113\u0006\u0017"+
		"\uffff\uffff\u0000\u0113\u0114\u0007\u0001\u0000\u0000\u0114\u0117\u0003"+
		".\u0017\u0003\u0115\u0117\u00032\u0019\u0000\u0116\u0112\u0001\u0000\u0000"+
		"\u0000\u0116\u0115\u0001\u0000\u0000\u0000\u0117\u012b\u0001\u0000\u0000"+
		"\u0000\u0118\u0119\n\b\u0000\u0000\u0119\u011a\u0007\u0002\u0000\u0000"+
		"\u011a\u012a\u0003.\u0017\t\u011b\u011c\n\u0007\u0000\u0000\u011c\u011d"+
		"\u0007\u0003\u0000\u0000\u011d\u012a\u0003.\u0017\b\u011e\u011f\n\u0006"+
		"\u0000\u0000\u011f\u0120\u0007\u0004\u0000\u0000\u0120\u012a\u0003.\u0017"+
		"\u0007\u0121\u0122\n\u0005\u0000\u0000\u0122\u0123\u0007\u0005\u0000\u0000"+
		"\u0123\u012a\u0003.\u0017\u0006\u0124\u0125\n\u0004\u0000\u0000\u0125"+
		"\u0126\u0007\u0006\u0000\u0000\u0126\u012a\u0003.\u0017\u0005\u0127\u0128"+
		"\n\u0002\u0000\u0000\u0128\u012a\u0007\u0007\u0000\u0000\u0129\u0118\u0001"+
		"\u0000\u0000\u0000\u0129\u011b\u0001\u0000\u0000\u0000\u0129\u011e\u0001"+
		"\u0000\u0000\u0000\u0129\u0121\u0001\u0000\u0000\u0000\u0129\u0124\u0001"+
		"\u0000\u0000\u0000\u0129\u0127\u0001\u0000\u0000\u0000\u012a\u012d\u0001"+
		"\u0000\u0000\u0000\u012b\u0129\u0001\u0000\u0000\u0000\u012b\u012c\u0001"+
		"\u0000\u0000\u0000\u012c/\u0001\u0000\u0000\u0000\u012d\u012b\u0001\u0000"+
		"\u0000\u0000\u012e\u0132\u0005\u0003\u0000\u0000\u012f\u0131\u0003*\u0015"+
		"\u0000\u0130\u012f\u0001\u0000\u0000\u0000\u0131\u0134\u0001\u0000\u0000"+
		"\u0000\u0132\u0130\u0001\u0000\u0000\u0000\u0132\u0133\u0001\u0000\u0000"+
		"\u0000\u0133\u0135\u0001\u0000\u0000\u0000\u0134\u0132\u0001\u0000\u0000"+
		"\u0000\u0135\u0136\u0005\u0003\u0000\u0000\u01361\u0001\u0000\u0000\u0000"+
		"\u0137\u0138\u0006\u0019\uffff\uffff\u0000\u0138\u0139\u00038\u001c\u0000"+
		"\u0139\u014c\u0001\u0000\u0000\u0000\u013a\u013c\n\u0002\u0000\u0000\u013b"+
		"\u013d\u00030\u0018\u0000\u013c\u013b\u0001\u0000\u0000\u0000\u013c\u013d"+
		"\u0001\u0000\u0000\u0000\u013d\u013e\u0001\u0000\u0000\u0000\u013e\u0147"+
		"\u00054\u0000\u0000\u013f\u0144\u0003,\u0016\u0000\u0140\u0141\u0005\u0002"+
		"\u0000\u0000\u0141\u0143\u0003,\u0016\u0000\u0142\u0140\u0001\u0000\u0000"+
		"\u0000\u0143\u0146\u0001\u0000\u0000\u0000\u0144\u0142\u0001\u0000\u0000"+
		"\u0000\u0144\u0145\u0001\u0000\u0000\u0000\u0145\u0148\u0001\u0000\u0000"+
		"\u0000\u0146\u0144\u0001\u0000\u0000\u0000\u0147\u013f\u0001\u0000\u0000"+
		"\u0000\u0147\u0148\u0001\u0000\u0000\u0000\u0148\u0149\u0001\u0000\u0000"+
		"\u0000\u0149\u014b\u00055\u0000\u0000\u014a\u013a\u0001\u0000\u0000\u0000"+
		"\u014b\u014e\u0001\u0000\u0000\u0000\u014c\u014a\u0001\u0000\u0000\u0000"+
		"\u014c\u014d\u0001\u0000\u0000\u0000\u014d3\u0001\u0000\u0000\u0000\u014e"+
		"\u014c\u0001\u0000\u0000\u0000\u014f\u0150\u0005\u001d\u0000\u0000\u0150"+
		"\u0151\u0003*\u0015\u0000\u0151\u0153\u00056\u0000\u0000\u0152\u0154\u0003"+
		"6\u001b\u0000\u0153\u0152\u0001\u0000\u0000\u0000\u0154\u0155\u0001\u0000"+
		"\u0000\u0000\u0155\u0153\u0001\u0000\u0000\u0000\u0155\u0156\u0001\u0000"+
		"\u0000\u0000\u0156\u0157\u0001\u0000\u0000\u0000\u0157\u0158\u00057\u0000"+
		"\u0000\u01585\u0001\u0000\u0000\u0000\u0159\u015a\u0005\u0012\u0000\u0000"+
		"\u015a\u015b\u0005)\u0000\u0000\u015b\u015c\u00052\u0000\u0000\u015c\u015d"+
		"\u0003,\u0016\u0000\u015d7\u0001\u0000\u0000\u0000\u015e\u015f\u0006\u001c"+
		"\uffff\uffff\u0000\u015f\u0160\u0003:\u001d\u0000\u0160\u0166\u0001\u0000"+
		"\u0000\u0000\u0161\u0162\n\u0002\u0000\u0000\u0162\u0163\u0005\u0001\u0000"+
		"\u0000\u0163\u0165\u0005)\u0000\u0000\u0164\u0161\u0001\u0000\u0000\u0000"+
		"\u0165\u0168\u0001\u0000\u0000\u0000\u0166\u0164\u0001\u0000\u0000\u0000"+
		"\u0166\u0167\u0001\u0000\u0000\u0000\u01679\u0001\u0000\u0000\u0000\u0168"+
		"\u0166\u0001\u0000\u0000\u0000\u0169\u0171\u0003<\u001e\u0000\u016a\u0171"+
		"\u0005)\u0000\u0000\u016b\u016c\u00054\u0000\u0000\u016c\u016d\u0003,"+
		"\u0016\u0000\u016d\u016e\u00055\u0000\u0000\u016e\u0171\u0001\u0000\u0000"+
		"\u0000\u016f\u0171\u00034\u001a\u0000\u0170\u0169\u0001\u0000\u0000\u0000"+
		"\u0170\u016a\u0001\u0000\u0000\u0000\u0170\u016b\u0001\u0000\u0000\u0000"+
		"\u0170\u016f\u0001\u0000\u0000\u0000\u0171;\u0001\u0000\u0000\u0000\u0172"+
		"\u0177\u0005*\u0000\u0000\u0173\u0177\u0005+\u0000\u0000\u0174\u0177\u0005"+
		",\u0000\u0000\u0175\u0177\u0003>\u001f\u0000\u0176\u0172\u0001\u0000\u0000"+
		"\u0000\u0176\u0173\u0001\u0000\u0000\u0000\u0176\u0174\u0001\u0000\u0000"+
		"\u0000\u0176\u0175\u0001\u0000\u0000\u0000\u0177=\u0001\u0000\u0000\u0000"+
		"\u0178\u0179\u0007\b\u0000\u0000\u0179?\u0001\u0000\u0000\u0000\'CLT]"+
		"dksy\u007f\u0089\u008c\u0090\u009d\u00ac\u00b8\u00be\u00ca\u00cf\u00d5"+
		"\u00e4\u00ec\u00f7\u00fa\u00fe\u0100\u0107\u010d\u0116\u0129\u012b\u0132"+
		"\u013c\u0144\u0147\u014c\u0155\u0166\u0170\u0176";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}