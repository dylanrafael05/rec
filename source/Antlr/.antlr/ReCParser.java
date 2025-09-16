// Generated from c:/Users/rafaed/Desktop/Programming/highc/ReC/Antlr/ReC.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class ReCParser extends Parser {
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
		RULE_program = 0, RULE_topLevelStatement = 1, RULE_modStatement = 2, RULE_useStatement = 3, 
		RULE_templateHeader = 4, RULE_structFieldDefine = 5, RULE_structDefine = 6, 
		RULE_fnArgumentDefine = 7, RULE_fnDefine = 8, RULE_aliasDefine = 9, RULE_block = 10, 
		RULE_statement = 11, RULE_returnStmt = 12, RULE_deferStmt = 13, RULE_ifStmt = 14, 
		RULE_ifTail = 15, RULE_whileStmt = 16, RULE_assignStmt = 17, RULE_letExpr = 18, 
		RULE_letStmt = 19, RULE_typenameFnArgs = 20, RULE_typename = 21, RULE_expr = 22, 
		RULE_opExpr = 23, RULE_explicitTemplateInstatiation = 24, RULE_callExpr = 25, 
		RULE_structExpr = 26, RULE_structExprAssign = 27, RULE_dotExpr = 28, RULE_termExpr = 29, 
		RULE_literal = 30, RULE_boolLiteral = 31;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "topLevelStatement", "modStatement", "useStatement", "templateHeader", 
			"structFieldDefine", "structDefine", "fnArgumentDefine", "fnDefine", 
			"aliasDefine", "block", "statement", "returnStmt", "deferStmt", "ifStmt", 
			"ifTail", "whileStmt", "assignStmt", "letExpr", "letStmt", "typenameFnArgs", 
			"typename", "expr", "opExpr", "explicitTemplateInstatiation", "callExpr", 
			"structExpr", "structExprAssign", "dotExpr", "termExpr", "literal", "boolLiteral"
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
	public String getGrammarFileName() { return "ReC.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public ReCParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends ParserRuleContext {
		public List<TopLevelStatementContext> topLevelStatement() {
			return getRuleContexts(TopLevelStatementContext.class);
		}
		public TopLevelStatementContext topLevelStatement(int i) {
			return getRuleContext(TopLevelStatementContext.class,i);
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
				topLevelStatement();
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
	public static class TopLevelStatementContext extends ParserRuleContext {
		public FnDefineContext fnDefine() {
			return getRuleContext(FnDefineContext.class,0);
		}
		public StructDefineContext structDefine() {
			return getRuleContext(StructDefineContext.class,0);
		}
		public AliasDefineContext aliasDefine() {
			return getRuleContext(AliasDefineContext.class,0);
		}
		public LetStmtContext letStmt() {
			return getRuleContext(LetStmtContext.class,0);
		}
		public ModStatementContext modStatement() {
			return getRuleContext(ModStatementContext.class,0);
		}
		public UseStatementContext useStatement() {
			return getRuleContext(UseStatementContext.class,0);
		}
		public TopLevelStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_topLevelStatement; }
	}

	public final TopLevelStatementContext topLevelStatement() throws RecognitionException {
		TopLevelStatementContext _localctx = new TopLevelStatementContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_topLevelStatement);
		try {
			setState(76);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(70);
				fnDefine();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(71);
				structDefine();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(72);
				aliasDefine();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(73);
				letStmt();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(74);
				modStatement();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(75);
				useStatement();
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
	public static class ModStatementContext extends ParserRuleContext {
		public Token Identifier;
		public List<Token> parts = new ArrayList<Token>();
		public TerminalNode Mod() { return getToken(ReCParser.Mod, 0); }
		public List<TerminalNode> Identifier() { return getTokens(ReCParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(ReCParser.Identifier, i);
		}
		public ModStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_modStatement; }
	}

	public final ModStatementContext modStatement() throws RecognitionException {
		ModStatementContext _localctx = new ModStatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_modStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(78);
			match(Mod);
			{
			setState(79);
			((ModStatementContext)_localctx).Identifier = match(Identifier);
			((ModStatementContext)_localctx).parts.add(((ModStatementContext)_localctx).Identifier);
			setState(84);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(80);
				match(T__0);
				setState(81);
				((ModStatementContext)_localctx).Identifier = match(Identifier);
				((ModStatementContext)_localctx).parts.add(((ModStatementContext)_localctx).Identifier);
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
	public static class UseStatementContext extends ParserRuleContext {
		public Token Identifier;
		public List<Token> parts = new ArrayList<Token>();
		public TerminalNode Use() { return getToken(ReCParser.Use, 0); }
		public List<TerminalNode> Identifier() { return getTokens(ReCParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(ReCParser.Identifier, i);
		}
		public UseStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_useStatement; }
	}

	public final UseStatementContext useStatement() throws RecognitionException {
		UseStatementContext _localctx = new UseStatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_useStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(87);
			match(Use);
			{
			setState(88);
			((UseStatementContext)_localctx).Identifier = match(Identifier);
			((UseStatementContext)_localctx).parts.add(((UseStatementContext)_localctx).Identifier);
			setState(93);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(89);
				match(T__0);
				setState(90);
				((UseStatementContext)_localctx).Identifier = match(Identifier);
				((UseStatementContext)_localctx).parts.add(((UseStatementContext)_localctx).Identifier);
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
	public static class TemplateHeaderContext extends ParserRuleContext {
		public Token Identifier;
		public List<Token> args = new ArrayList<Token>();
		public TerminalNode Template() { return getToken(ReCParser.Template, 0); }
		public List<TerminalNode> Identifier() { return getTokens(ReCParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(ReCParser.Identifier, i);
		}
		public TemplateHeaderContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_templateHeader; }
	}

	public final TemplateHeaderContext templateHeader() throws RecognitionException {
		TemplateHeaderContext _localctx = new TemplateHeaderContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_templateHeader);
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
				((TemplateHeaderContext)_localctx).Identifier = match(Identifier);
				((TemplateHeaderContext)_localctx).args.add(((TemplateHeaderContext)_localctx).Identifier);
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
	public static class StructFieldDefineContext extends ParserRuleContext {
		public Token name;
		public TypenameContext type;
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public StructFieldDefineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structFieldDefine; }
	}

	public final StructFieldDefineContext structFieldDefine() throws RecognitionException {
		StructFieldDefineContext _localctx = new StructFieldDefineContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_structFieldDefine);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			((StructFieldDefineContext)_localctx).name = match(Identifier);
			setState(103);
			((StructFieldDefineContext)_localctx).type = typename(0);
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
	public static class StructDefineContext extends ParserRuleContext {
		public Token name;
		public StructFieldDefineContext structFieldDefine;
		public List<StructFieldDefineContext> fields = new ArrayList<StructFieldDefineContext>();
		public TerminalNode Struct() { return getToken(ReCParser.Struct, 0); }
		public TerminalNode OpenBrace() { return getToken(ReCParser.OpenBrace, 0); }
		public TerminalNode CloseBrace() { return getToken(ReCParser.CloseBrace, 0); }
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TemplateHeaderContext templateHeader() {
			return getRuleContext(TemplateHeaderContext.class,0);
		}
		public List<StructFieldDefineContext> structFieldDefine() {
			return getRuleContexts(StructFieldDefineContext.class);
		}
		public StructFieldDefineContext structFieldDefine(int i) {
			return getRuleContext(StructFieldDefineContext.class,i);
		}
		public StructDefineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structDefine; }
	}

	public final StructDefineContext structDefine() throws RecognitionException {
		StructDefineContext _localctx = new StructDefineContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_structDefine);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(106);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Template) {
				{
				setState(105);
				templateHeader();
				}
			}

			setState(108);
			match(Struct);
			setState(109);
			((StructDefineContext)_localctx).name = match(Identifier);
			setState(110);
			match(OpenBrace);
			setState(116);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(111);
					((StructDefineContext)_localctx).structFieldDefine = structFieldDefine();
					((StructDefineContext)_localctx).fields.add(((StructDefineContext)_localctx).structFieldDefine);
					setState(112);
					match(T__1);
					}
					} 
				}
				setState(118);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			}
			setState(123);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Identifier) {
				{
				setState(119);
				((StructDefineContext)_localctx).structFieldDefine = structFieldDefine();
				((StructDefineContext)_localctx).fields.add(((StructDefineContext)_localctx).structFieldDefine);
				setState(121);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__1) {
					{
					setState(120);
					match(T__1);
					}
				}

				}
			}

			setState(125);
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
	public static class FnArgumentDefineContext extends ParserRuleContext {
		public Token auto;
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Auto() { return getToken(ReCParser.Auto, 0); }
		public FnArgumentDefineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fnArgumentDefine; }
	}

	public final FnArgumentDefineContext fnArgumentDefine() throws RecognitionException {
		FnArgumentDefineContext _localctx = new FnArgumentDefineContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_fnArgumentDefine);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(128);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Auto) {
				{
				setState(127);
				((FnArgumentDefineContext)_localctx).auto = match(Auto);
				}
			}

			setState(130);
			match(Identifier);
			setState(131);
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
	public static class FnDefineContext extends ParserRuleContext {
		public Token name;
		public FnArgumentDefineContext fnArgumentDefine;
		public List<FnArgumentDefineContext> args = new ArrayList<FnArgumentDefineContext>();
		public TypenameContext ret;
		public TerminalNode Fn() { return getToken(ReCParser.Fn, 0); }
		public TerminalNode OpenParen() { return getToken(ReCParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(ReCParser.CloseParen, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TemplateHeaderContext templateHeader() {
			return getRuleContext(TemplateHeaderContext.class,0);
		}
		public List<FnArgumentDefineContext> fnArgumentDefine() {
			return getRuleContexts(FnArgumentDefineContext.class);
		}
		public FnArgumentDefineContext fnArgumentDefine(int i) {
			return getRuleContext(FnArgumentDefineContext.class,i);
		}
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public FnDefineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fnDefine; }
	}

	public final FnDefineContext fnDefine() throws RecognitionException {
		FnDefineContext _localctx = new FnDefineContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_fnDefine);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(134);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Template) {
				{
				setState(133);
				templateHeader();
				}
			}

			setState(136);
			match(Fn);
			setState(137);
			((FnDefineContext)_localctx).name = match(Identifier);
			setState(138);
			match(OpenParen);
			setState(147);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Auto || _la==Identifier) {
				{
				setState(139);
				((FnDefineContext)_localctx).fnArgumentDefine = fnArgumentDefine();
				((FnDefineContext)_localctx).args.add(((FnDefineContext)_localctx).fnArgumentDefine);
				setState(144);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__1) {
					{
					{
					setState(140);
					match(T__1);
					setState(141);
					((FnDefineContext)_localctx).fnArgumentDefine = fnArgumentDefine();
					((FnDefineContext)_localctx).args.add(((FnDefineContext)_localctx).fnArgumentDefine);
					}
					}
					setState(146);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(149);
			match(CloseParen);
			setState(151);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
				{
				setState(150);
				((FnDefineContext)_localctx).ret = typename(0);
				}
			}

			setState(153);
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
	public static class AliasDefineContext extends ParserRuleContext {
		public Token name;
		public TerminalNode Type() { return getToken(ReCParser.Type, 0); }
		public TerminalNode Equal() { return getToken(ReCParser.Equal, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public AliasDefineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aliasDefine; }
	}

	public final AliasDefineContext aliasDefine() throws RecognitionException {
		AliasDefineContext _localctx = new AliasDefineContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_aliasDefine);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(155);
			match(Type);
			setState(156);
			((AliasDefineContext)_localctx).name = match(Identifier);
			setState(157);
			match(Equal);
			setState(158);
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
		public TerminalNode OpenBrace() { return getToken(ReCParser.OpenBrace, 0); }
		public TerminalNode CloseBrace() { return getToken(ReCParser.CloseBrace, 0); }
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
			setState(160);
			match(OpenBrace);
			setState(164);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 22657431627505664L) != 0)) {
				{
				{
				setState(161);
				((BlockContext)_localctx).statement = statement();
				((BlockContext)_localctx).stmts.add(((BlockContext)_localctx).statement);
				}
				}
				setState(166);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(167);
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
		public AssignStmtContext assignStmt() {
			return getRuleContext(AssignStmtContext.class,0);
		}
		public LetStmtContext letStmt() {
			return getRuleContext(LetStmtContext.class,0);
		}
		public IfStmtContext ifStmt() {
			return getRuleContext(IfStmtContext.class,0);
		}
		public WhileStmtContext whileStmt() {
			return getRuleContext(WhileStmtContext.class,0);
		}
		public DeferStmtContext deferStmt() {
			return getRuleContext(DeferStmtContext.class,0);
		}
		public ReturnStmtContext returnStmt() {
			return getRuleContext(ReturnStmtContext.class,0);
		}
		public TerminalNode Continue() { return getToken(ReCParser.Continue, 0); }
		public TerminalNode Break() { return getToken(ReCParser.Break, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
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
			setState(179);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(169);
				assignStmt();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(170);
				letStmt();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(171);
				ifStmt();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(172);
				whileStmt();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(173);
				deferStmt();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(174);
				returnStmt();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(175);
				match(Continue);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(176);
				match(Break);
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(177);
				block();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(178);
				expr();
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
	public static class ReturnStmtContext extends ParserRuleContext {
		public ExprContext value;
		public TerminalNode Return() { return getToken(ReCParser.Return, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public ReturnStmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStmt; }
	}

	public final ReturnStmtContext returnStmt() throws RecognitionException {
		ReturnStmtContext _localctx = new ReturnStmtContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_returnStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(181);
			match(Return);
			setState(182);
			((ReturnStmtContext)_localctx).value = expr();
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
	public static class DeferStmtContext extends ParserRuleContext {
		public TerminalNode Defer() { return getToken(ReCParser.Defer, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public DeferStmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_deferStmt; }
	}

	public final DeferStmtContext deferStmt() throws RecognitionException {
		DeferStmtContext _localctx = new DeferStmtContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_deferStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(184);
			match(Defer);
			setState(185);
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
	public static class IfStmtContext extends ParserRuleContext {
		public ExprContext cond;
		public TerminalNode If() { return getToken(ReCParser.If, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public IfTailContext ifTail() {
			return getRuleContext(IfTailContext.class,0);
		}
		public IfStmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStmt; }
	}

	public final IfStmtContext ifStmt() throws RecognitionException {
		IfStmtContext _localctx = new IfStmtContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_ifStmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(187);
			match(If);
			setState(188);
			((IfStmtContext)_localctx).cond = expr();
			setState(189);
			block();
			setState(191);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Else) {
				{
				setState(190);
				ifTail();
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
	public static class IfTailContext extends ParserRuleContext {
		public BlockContext end_block;
		public IfStmtContext elif;
		public TerminalNode Else() { return getToken(ReCParser.Else, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public IfStmtContext ifStmt() {
			return getRuleContext(IfStmtContext.class,0);
		}
		public IfTailContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifTail; }
	}

	public final IfTailContext ifTail() throws RecognitionException {
		IfTailContext _localctx = new IfTailContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_ifTail);
		try {
			setState(197);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(193);
				match(Else);
				setState(194);
				((IfTailContext)_localctx).end_block = block();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(195);
				match(Else);
				setState(196);
				((IfTailContext)_localctx).elif = ifStmt();
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
	public static class WhileStmtContext extends ParserRuleContext {
		public ExprContext cond;
		public TerminalNode While() { return getToken(ReCParser.While, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public WhileStmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileStmt; }
	}

	public final WhileStmtContext whileStmt() throws RecognitionException {
		WhileStmtContext _localctx = new WhileStmtContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_whileStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(199);
			match(While);
			setState(200);
			((WhileStmtContext)_localctx).cond = expr();
			setState(201);
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
	public static class AssignStmtContext extends ParserRuleContext {
		public ExprContext target;
		public ExprContext value;
		public TerminalNode Equal() { return getToken(ReCParser.Equal, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public AssignStmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignStmt; }
	}

	public final AssignStmtContext assignStmt() throws RecognitionException {
		AssignStmtContext _localctx = new AssignStmtContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_assignStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203);
			((AssignStmtContext)_localctx).target = expr();
			setState(204);
			match(Equal);
			setState(205);
			((AssignStmtContext)_localctx).value = expr();
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
	public static class LetExprContext extends ParserRuleContext {
		public TerminalNode Uninit() { return getToken(ReCParser.Uninit, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public LetExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_letExpr; }
	}

	public final LetExprContext letExpr() throws RecognitionException {
		LetExprContext _localctx = new LetExprContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_letExpr);
		try {
			setState(209);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case Uninit:
				enterOuterAlt(_localctx, 1);
				{
				setState(207);
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
				setState(208);
				expr();
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
	public static class LetStmtContext extends ParserRuleContext {
		public Token spec;
		public Token target;
		public TypenameContext type;
		public LetExprContext value;
		public TerminalNode Equal() { return getToken(ReCParser.Equal, 0); }
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public LetExprContext letExpr() {
			return getRuleContext(LetExprContext.class,0);
		}
		public TerminalNode Let() { return getToken(ReCParser.Let, 0); }
		public TerminalNode Var() { return getToken(ReCParser.Var, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public LetStmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_letStmt; }
	}

	public final LetStmtContext letStmt() throws RecognitionException {
		LetStmtContext _localctx = new LetStmtContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_letStmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(211);
			((LetStmtContext)_localctx).spec = _input.LT(1);
			_la = _input.LA(1);
			if ( !(_la==Var || _la==Let) ) {
				((LetStmtContext)_localctx).spec = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(212);
			((LetStmtContext)_localctx).target = match(Identifier);
			setState(214);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
				{
				setState(213);
				((LetStmtContext)_localctx).type = typename(0);
				}
			}

			setState(216);
			match(Equal);
			setState(217);
			((LetStmtContext)_localctx).value = letExpr();
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
	public static class TypenameFnArgsContext extends ParserRuleContext {
		public TypenameContext type;
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TypenameFnArgsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typenameFnArgs; }
	}

	public final TypenameFnArgsContext typenameFnArgs() throws RecognitionException {
		TypenameFnArgsContext _localctx = new TypenameFnArgsContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_typenameFnArgs);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(220);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				{
				setState(219);
				match(Identifier);
				}
				break;
			}
			setState(222);
			((TypenameFnArgsContext)_localctx).type = typename(0);
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
		public List<TerminalNode> Identifier() { return getTokens(ReCParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(ReCParser.Identifier, i);
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
		public TypenameFnArgsContext typenameFnArgs;
		public List<TypenameFnArgsContext> args = new ArrayList<TypenameFnArgsContext>();
		public TypenameContext ret;
		public TerminalNode Fn() { return getToken(ReCParser.Fn, 0); }
		public TerminalNode OpenParen() { return getToken(ReCParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(ReCParser.CloseParen, 0); }
		public List<TypenameFnArgsContext> typenameFnArgs() {
			return getRuleContexts(TypenameFnArgsContext.class);
		}
		public TypenameFnArgsContext typenameFnArgs(int i) {
			return getRuleContext(TypenameFnArgsContext.class,i);
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
		public TerminalNode OpenIndex() { return getToken(ReCParser.OpenIndex, 0); }
		public TerminalNode CloseIndex() { return getToken(ReCParser.CloseIndex, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode Integer() { return getToken(ReCParser.Integer, 0); }
		public TypenameArrayContext(TypenameContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenameSingleContext extends TypenameContext {
		public TypenameContext inner;
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TerminalNode OpenParen() { return getToken(ReCParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(ReCParser.CloseParen, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TypenameSingleContext(TypenameContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TypenamePointerContext extends TypenameContext {
		public TypenameContext base;
		public TerminalNode Star() { return getToken(ReCParser.Star, 0); }
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
			setState(263);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				{
				_localctx = new TypenameSingleContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(225);
				match(Identifier);
				}
				break;
			case 2:
				{
				_localctx = new TypenameSingleContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(226);
				match(OpenParen);
				setState(227);
				((TypenameSingleContext)_localctx).inner = typename(0);
				setState(228);
				match(CloseParen);
				}
				break;
			case 3:
				{
				_localctx = new TypenameManyContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(230);
				((TypenameManyContext)_localctx).Identifier = match(Identifier);
				((TypenameManyContext)_localctx).parts.add(((TypenameManyContext)_localctx).Identifier);
				setState(233); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(231);
						match(T__0);
						setState(232);
						((TypenameManyContext)_localctx).Identifier = match(Identifier);
						((TypenameManyContext)_localctx).parts.add(((TypenameManyContext)_localctx).Identifier);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(235); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			case 4:
				{
				_localctx = new TypenamePointerContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(237);
				match(Star);
				setState(238);
				((TypenamePointerContext)_localctx).base = typename(3);
				}
				break;
			case 5:
				{
				_localctx = new TypenameArrayContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(239);
				match(OpenIndex);
				setState(240);
				((TypenameArrayContext)_localctx).base = typename(0);
				setState(243);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__3) {
					{
					setState(241);
					match(T__3);
					setState(242);
					((TypenameArrayContext)_localctx).count = match(Integer);
					}
				}

				setState(245);
				match(CloseIndex);
				}
				break;
			case 6:
				{
				_localctx = new TypenameFnContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(247);
				match(Fn);
				setState(248);
				match(OpenParen);
				setState(257);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
					{
					setState(249);
					((TypenameFnContext)_localctx).typenameFnArgs = typenameFnArgs();
					((TypenameFnContext)_localctx).args.add(((TypenameFnContext)_localctx).typenameFnArgs);
					setState(254);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==T__1) {
						{
						{
						setState(250);
						match(T__1);
						setState(251);
						((TypenameFnContext)_localctx).typenameFnArgs = typenameFnArgs();
						((TypenameFnContext)_localctx).args.add(((TypenameFnContext)_localctx).typenameFnArgs);
						}
						}
						setState(256);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(259);
				match(CloseParen);
				setState(261);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
				case 1:
					{
					setState(260);
					((TypenameFnContext)_localctx).ret = typename(0);
					}
					break;
				}
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(276);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TypenameGenericContext(new TypenameContext(_parentctx, _parentState));
					((TypenameGenericContext)_localctx).base = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_typename);
					setState(265);
					if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
					setState(266);
					match(T__2);
					setState(268); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(267);
						((TypenameGenericContext)_localctx).typename = typename(0);
						((TypenameGenericContext)_localctx).args.add(((TypenameGenericContext)_localctx).typename);
						}
						}
						setState(270); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0) );
					setState(272);
					match(T__2);
					}
					} 
				}
				setState(278);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
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
	public static class ExprContext extends ParserRuleContext {
		public OpExprContext opExpr() {
			return getRuleContext(OpExprContext.class,0);
		}
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	}

	public final ExprContext expr() throws RecognitionException {
		ExprContext _localctx = new ExprContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(279);
			opExpr(0);
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
	public static class OpExprContext extends ParserRuleContext {
		public OpExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_opExpr; }
	 
		public OpExprContext() { }
		public void copyFrom(OpExprContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AddExpressionContext extends OpExprContext {
		public OpExprContext rhs;
		public List<OpExprContext> opExpr() {
			return getRuleContexts(OpExprContext.class);
		}
		public OpExprContext opExpr(int i) {
			return getRuleContext(OpExprContext.class,i);
		}
		public TerminalNode Plus() { return getToken(ReCParser.Plus, 0); }
		public TerminalNode Minus() { return getToken(ReCParser.Minus, 0); }
		public AddExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LogicExpressionContext extends OpExprContext {
		public OpExprContext lhs;
		public List<OpExprContext> opExpr() {
			return getRuleContexts(OpExprContext.class);
		}
		public OpExprContext opExpr(int i) {
			return getRuleContext(OpExprContext.class,i);
		}
		public TerminalNode And() { return getToken(ReCParser.And, 0); }
		public TerminalNode Or() { return getToken(ReCParser.Or, 0); }
		public LogicExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MemoryExpressionContext extends OpExprContext {
		public OpExprContext op;
		public OpExprContext opExpr() {
			return getRuleContext(OpExprContext.class,0);
		}
		public TerminalNode Star() { return getToken(ReCParser.Star, 0); }
		public TerminalNode Ampersand() { return getToken(ReCParser.Ampersand, 0); }
		public MemoryExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class UnaryExpressionContext extends OpExprContext {
		public OpExprContext op;
		public TerminalNode Plus() { return getToken(ReCParser.Plus, 0); }
		public TerminalNode Minus() { return getToken(ReCParser.Minus, 0); }
		public TerminalNode Not() { return getToken(ReCParser.Not, 0); }
		public OpExprContext opExpr() {
			return getRuleContext(OpExprContext.class,0);
		}
		public UnaryExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CompareExpressionContext extends OpExprContext {
		public OpExprContext lhs;
		public List<OpExprContext> opExpr() {
			return getRuleContexts(OpExprContext.class);
		}
		public OpExprContext opExpr(int i) {
			return getRuleContext(OpExprContext.class,i);
		}
		public TerminalNode CompEqual() { return getToken(ReCParser.CompEqual, 0); }
		public CompareExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CallExpressionContext extends OpExprContext {
		public CallExprContext callExpr() {
			return getRuleContext(CallExprContext.class,0);
		}
		public CallExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MulExpressionContext extends OpExprContext {
		public OpExprContext lhs;
		public List<OpExprContext> opExpr() {
			return getRuleContexts(OpExprContext.class);
		}
		public OpExprContext opExpr(int i) {
			return getRuleContext(OpExprContext.class,i);
		}
		public TerminalNode Star() { return getToken(ReCParser.Star, 0); }
		public TerminalNode Slash() { return getToken(ReCParser.Slash, 0); }
		public MulExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class BitwiseExpressionContext extends OpExprContext {
		public OpExprContext rhs;
		public List<OpExprContext> opExpr() {
			return getRuleContexts(OpExprContext.class);
		}
		public OpExprContext opExpr(int i) {
			return getRuleContext(OpExprContext.class,i);
		}
		public TerminalNode Ampersand() { return getToken(ReCParser.Ampersand, 0); }
		public BitwiseExpressionContext(OpExprContext ctx) { copyFrom(ctx); }
	}

	public final OpExprContext opExpr() throws RecognitionException {
		return opExpr(0);
	}

	private OpExprContext opExpr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		OpExprContext _localctx = new OpExprContext(_ctx, _parentState);
		OpExprContext _prevctx = _localctx;
		int _startState = 46;
		enterRecursionRule(_localctx, 46, RULE_opExpr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(285);
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

				setState(282);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 105621835751424L) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(283);
				((UnaryExpressionContext)_localctx).op = opExpr(3);
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
				setState(284);
				callExpr(0);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(306);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,31,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(304);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
					case 1:
						{
						_localctx = new LogicExpressionContext(new OpExprContext(_parentctx, _parentState));
						((LogicExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(287);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(288);
						_la = _input.LA(1);
						if ( !(_la==And || _la==Or) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(289);
						((LogicExpressionContext)_localctx).lhs = opExpr(9);
						}
						break;
					case 2:
						{
						_localctx = new CompareExpressionContext(new OpExprContext(_parentctx, _parentState));
						((CompareExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(290);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(291);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 2251799813686240L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(292);
						((CompareExpressionContext)_localctx).lhs = opExpr(8);
						}
						break;
					case 3:
						{
						_localctx = new MulExpressionContext(new OpExprContext(_parentctx, _parentState));
						((MulExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(293);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(294);
						_la = _input.LA(1);
						if ( !(_la==Star || _la==Slash) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(295);
						((MulExpressionContext)_localctx).lhs = opExpr(7);
						}
						break;
					case 4:
						{
						_localctx = new BitwiseExpressionContext(new OpExprContext(_parentctx, _parentState));
						((BitwiseExpressionContext)_localctx).rhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(296);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(297);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 562949953428480L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(298);
						((BitwiseExpressionContext)_localctx).rhs = opExpr(6);
						}
						break;
					case 5:
						{
						_localctx = new AddExpressionContext(new OpExprContext(_parentctx, _parentState));
						((AddExpressionContext)_localctx).rhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(299);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(300);
						_la = _input.LA(1);
						if ( !(_la==Plus || _la==Minus) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(301);
						((AddExpressionContext)_localctx).rhs = opExpr(5);
						}
						break;
					case 6:
						{
						_localctx = new MemoryExpressionContext(new OpExprContext(_parentctx, _parentState));
						((MemoryExpressionContext)_localctx).op = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(302);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(303);
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
				setState(308);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,31,_ctx);
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
	public static class ExplicitTemplateInstatiationContext extends ParserRuleContext {
		public TypenameContext typename;
		public List<TypenameContext> args = new ArrayList<TypenameContext>();
		public List<TypenameContext> typename() {
			return getRuleContexts(TypenameContext.class);
		}
		public TypenameContext typename(int i) {
			return getRuleContext(TypenameContext.class,i);
		}
		public ExplicitTemplateInstatiationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_explicitTemplateInstatiation; }
	}

	public final ExplicitTemplateInstatiationContext explicitTemplateInstatiation() throws RecognitionException {
		ExplicitTemplateInstatiationContext _localctx = new ExplicitTemplateInstatiationContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_explicitTemplateInstatiation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(309);
			match(T__2);
			setState(313);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 76704130181103616L) != 0)) {
				{
				{
				setState(310);
				((ExplicitTemplateInstatiationContext)_localctx).typename = typename(0);
				((ExplicitTemplateInstatiationContext)_localctx).args.add(((ExplicitTemplateInstatiationContext)_localctx).typename);
				}
				}
				setState(315);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(316);
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
	public static class CallExprContext extends ParserRuleContext {
		public CallExprContext target;
		public ExplicitTemplateInstatiationContext inst;
		public ExprContext expr;
		public List<ExprContext> args = new ArrayList<ExprContext>();
		public DotExprContext dotExpr() {
			return getRuleContext(DotExprContext.class,0);
		}
		public TerminalNode OpenParen() { return getToken(ReCParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(ReCParser.CloseParen, 0); }
		public CallExprContext callExpr() {
			return getRuleContext(CallExprContext.class,0);
		}
		public ExplicitTemplateInstatiationContext explicitTemplateInstatiation() {
			return getRuleContext(ExplicitTemplateInstatiationContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public CallExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_callExpr; }
	}

	public final CallExprContext callExpr() throws RecognitionException {
		return callExpr(0);
	}

	private CallExprContext callExpr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		CallExprContext _localctx = new CallExprContext(_ctx, _parentState);
		CallExprContext _prevctx = _localctx;
		int _startState = 50;
		enterRecursionRule(_localctx, 50, RULE_callExpr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(319);
			dotExpr(0);
			}
			_ctx.stop = _input.LT(-1);
			setState(339);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new CallExprContext(_parentctx, _parentState);
					_localctx.target = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_callExpr);
					setState(321);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(323);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==T__2) {
						{
						setState(322);
						((CallExprContext)_localctx).inst = explicitTemplateInstatiation();
						}
					}

					setState(325);
					match(OpenParen);
					setState(334);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4643031982546944L) != 0)) {
						{
						setState(326);
						((CallExprContext)_localctx).expr = expr();
						((CallExprContext)_localctx).args.add(((CallExprContext)_localctx).expr);
						setState(331);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==T__1) {
							{
							{
							setState(327);
							match(T__1);
							setState(328);
							((CallExprContext)_localctx).expr = expr();
							((CallExprContext)_localctx).args.add(((CallExprContext)_localctx).expr);
							}
							}
							setState(333);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						}
					}

					setState(336);
					match(CloseParen);
					}
					} 
				}
				setState(341);
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
	public static class StructExprContext extends ParserRuleContext {
		public StructExprAssignContext structExprAssign;
		public List<StructExprAssignContext> parts = new ArrayList<StructExprAssignContext>();
		public TerminalNode New() { return getToken(ReCParser.New, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode OpenBrace() { return getToken(ReCParser.OpenBrace, 0); }
		public TerminalNode CloseBrace() { return getToken(ReCParser.CloseBrace, 0); }
		public List<StructExprAssignContext> structExprAssign() {
			return getRuleContexts(StructExprAssignContext.class);
		}
		public StructExprAssignContext structExprAssign(int i) {
			return getRuleContext(StructExprAssignContext.class,i);
		}
		public StructExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structExpr; }
	}

	public final StructExprContext structExpr() throws RecognitionException {
		StructExprContext _localctx = new StructExprContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_structExpr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(342);
			match(New);
			setState(343);
			typename(0);
			setState(344);
			match(OpenBrace);
			setState(346); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(345);
				((StructExprContext)_localctx).structExprAssign = structExprAssign();
				((StructExprContext)_localctx).parts.add(((StructExprContext)_localctx).structExprAssign);
				}
				}
				setState(348); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==Identifier );
			setState(350);
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
	public static class StructExprAssignContext extends ParserRuleContext {
		public Token Field;
		public ExprContext Value;
		public TerminalNode Equal() { return getToken(ReCParser.Equal, 0); }
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public StructExprAssignContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structExprAssign; }
	}

	public final StructExprAssignContext structExprAssign() throws RecognitionException {
		StructExprAssignContext _localctx = new StructExprAssignContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_structExprAssign);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(352);
			((StructExprAssignContext)_localctx).Field = match(Identifier);
			setState(353);
			match(Equal);
			setState(354);
			((StructExprAssignContext)_localctx).Value = expr();
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
	public static class DotExprContext extends ParserRuleContext {
		public Token Field;
		public TermExprContext termExpr() {
			return getRuleContext(TermExprContext.class,0);
		}
		public DotExprContext dotExpr() {
			return getRuleContext(DotExprContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public DotExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_dotExpr; }
	}

	public final DotExprContext dotExpr() throws RecognitionException {
		return dotExpr(0);
	}

	private DotExprContext dotExpr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		DotExprContext _localctx = new DotExprContext(_ctx, _parentState);
		DotExprContext _prevctx = _localctx;
		int _startState = 56;
		enterRecursionRule(_localctx, 56, RULE_dotExpr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(357);
			termExpr();
			}
			_ctx.stop = _input.LT(-1);
			setState(364);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new DotExprContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_dotExpr);
					setState(359);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(360);
					match(T__0);
					setState(361);
					((DotExprContext)_localctx).Field = match(Identifier);
					}
					} 
				}
				setState(366);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
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
	public static class TermExprContext extends ParserRuleContext {
		public LiteralContext literal() {
			return getRuleContext(LiteralContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TerminalNode OpenParen() { return getToken(ReCParser.OpenParen, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CloseParen() { return getToken(ReCParser.CloseParen, 0); }
		public StructExprContext structExpr() {
			return getRuleContext(StructExprContext.class,0);
		}
		public TermExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_termExpr; }
	}

	public final TermExprContext termExpr() throws RecognitionException {
		TermExprContext _localctx = new TermExprContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_termExpr);
		try {
			setState(374);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case True:
			case False:
			case Integer:
			case Float:
			case String:
				enterOuterAlt(_localctx, 1);
				{
				setState(367);
				literal();
				}
				break;
			case Identifier:
				enterOuterAlt(_localctx, 2);
				{
				setState(368);
				match(Identifier);
				}
				break;
			case OpenParen:
				enterOuterAlt(_localctx, 3);
				{
				setState(369);
				match(OpenParen);
				setState(370);
				expr();
				setState(371);
				match(CloseParen);
				}
				break;
			case New:
				enterOuterAlt(_localctx, 4);
				{
				setState(373);
				structExpr();
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
		public TerminalNode Integer() { return getToken(ReCParser.Integer, 0); }
		public TerminalNode Float() { return getToken(ReCParser.Float, 0); }
		public TerminalNode String() { return getToken(ReCParser.String, 0); }
		public BoolLiteralContext boolLiteral() {
			return getRuleContext(BoolLiteralContext.class,0);
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
			setState(380);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case Integer:
				enterOuterAlt(_localctx, 1);
				{
				setState(376);
				match(Integer);
				}
				break;
			case Float:
				enterOuterAlt(_localctx, 2);
				{
				setState(377);
				match(Float);
				}
				break;
			case String:
				enterOuterAlt(_localctx, 3);
				{
				setState(378);
				match(String);
				}
				break;
			case True:
			case False:
				enterOuterAlt(_localctx, 4);
				{
				setState(379);
				boolLiteral();
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
	public static class BoolLiteralContext extends ParserRuleContext {
		public TerminalNode True() { return getToken(ReCParser.True, 0); }
		public TerminalNode False() { return getToken(ReCParser.False, 0); }
		public BoolLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolLiteral; }
	}

	public final BoolLiteralContext boolLiteral() throws RecognitionException {
		BoolLiteralContext _localctx = new BoolLiteralContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_boolLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(382);
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
			return opExpr_sempred((OpExprContext)_localctx, predIndex);
		case 25:
			return callExpr_sempred((CallExprContext)_localctx, predIndex);
		case 28:
			return dotExpr_sempred((DotExprContext)_localctx, predIndex);
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
	private boolean opExpr_sempred(OpExprContext _localctx, int predIndex) {
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
	private boolean callExpr_sempred(CallExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 7:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean dotExpr_sempred(DotExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 8:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u00019\u0181\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
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
		"d\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0003\u0006k\b\u0006"+
		"\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0005\u0006s\b\u0006\n\u0006\f\u0006v\t\u0006\u0001\u0006\u0001\u0006"+
		"\u0003\u0006z\b\u0006\u0003\u0006|\b\u0006\u0001\u0006\u0001\u0006\u0001"+
		"\u0007\u0003\u0007\u0081\b\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\b\u0003\b\u0087\b\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0005"+
		"\b\u008f\b\b\n\b\f\b\u0092\t\b\u0003\b\u0094\b\b\u0001\b\u0001\b\u0003"+
		"\b\u0098\b\b\u0001\b\u0001\b\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001"+
		"\n\u0001\n\u0005\n\u00a3\b\n\n\n\f\n\u00a6\t\n\u0001\n\u0001\n\u0001\u000b"+
		"\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b"+
		"\u0001\u000b\u0001\u000b\u0001\u000b\u0003\u000b\u00b4\b\u000b\u0001\f"+
		"\u0001\f\u0001\f\u0001\r\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001"+
		"\u000e\u0001\u000e\u0003\u000e\u00c0\b\u000e\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0003\u000f\u00c6\b\u000f\u0001\u0010\u0001\u0010\u0001"+
		"\u0010\u0001\u0010\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001"+
		"\u0012\u0001\u0012\u0003\u0012\u00d2\b\u0012\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0003\u0013\u00d7\b\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0014\u0003\u0014\u00dd\b\u0014\u0001\u0014\u0001\u0014\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0004\u0015\u00ea\b\u0015\u000b\u0015\f\u0015\u00eb"+
		"\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015"+
		"\u0003\u0015\u00f4\b\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015"+
		"\u0001\u0015\u0001\u0015\u0001\u0015\u0005\u0015\u00fd\b\u0015\n\u0015"+
		"\f\u0015\u0100\t\u0015\u0003\u0015\u0102\b\u0015\u0001\u0015\u0001\u0015"+
		"\u0003\u0015\u0106\b\u0015\u0003\u0015\u0108\b\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0004\u0015\u010d\b\u0015\u000b\u0015\f\u0015\u010e"+
		"\u0001\u0015\u0001\u0015\u0005\u0015\u0113\b\u0015\n\u0015\f\u0015\u0116"+
		"\t\u0015\u0001\u0016\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001"+
		"\u0017\u0003\u0017\u011e\b\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001"+
		"\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001"+
		"\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001"+
		"\u0017\u0001\u0017\u0005\u0017\u0131\b\u0017\n\u0017\f\u0017\u0134\t\u0017"+
		"\u0001\u0018\u0001\u0018\u0005\u0018\u0138\b\u0018\n\u0018\f\u0018\u013b"+
		"\t\u0018\u0001\u0018\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0001"+
		"\u0019\u0001\u0019\u0003\u0019\u0144\b\u0019\u0001\u0019\u0001\u0019\u0001"+
		"\u0019\u0001\u0019\u0005\u0019\u014a\b\u0019\n\u0019\f\u0019\u014d\t\u0019"+
		"\u0003\u0019\u014f\b\u0019\u0001\u0019\u0005\u0019\u0152\b\u0019\n\u0019"+
		"\f\u0019\u0155\t\u0019\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a"+
		"\u0004\u001a\u015b\b\u001a\u000b\u001a\f\u001a\u015c\u0001\u001a\u0001"+
		"\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001c\u0001"+
		"\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0005\u001c\u016b"+
		"\b\u001c\n\u001c\f\u001c\u016e\t\u001c\u0001\u001d\u0001\u001d\u0001\u001d"+
		"\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0003\u001d\u0177\b\u001d"+
		"\u0001\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0003\u001e\u017d\b\u001e"+
		"\u0001\u001f\u0001\u001f\u0001\u001f\u0000\u0004*.28 \u0000\u0002\u0004"+
		"\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e \""+
		"$&(*,.02468:<>\u0000\t\u0001\u0000\u0011\u0012\u0003\u0000\r\r$$-.\u0002"+
		"\u0000##%%\u0002\u0000\u0005\t33\u0001\u0000/0\u0002\u0000\n\f11\u0001"+
		"\u0000-.\u0002\u0000//11\u0001\u0000&\'\u01a1\u0000C\u0001\u0000\u0000"+
		"\u0000\u0002L\u0001\u0000\u0000\u0000\u0004N\u0001\u0000\u0000\u0000\u0006"+
		"W\u0001\u0000\u0000\u0000\b`\u0001\u0000\u0000\u0000\nf\u0001\u0000\u0000"+
		"\u0000\fj\u0001\u0000\u0000\u0000\u000e\u0080\u0001\u0000\u0000\u0000"+
		"\u0010\u0086\u0001\u0000\u0000\u0000\u0012\u009b\u0001\u0000\u0000\u0000"+
		"\u0014\u00a0\u0001\u0000\u0000\u0000\u0016\u00b3\u0001\u0000\u0000\u0000"+
		"\u0018\u00b5\u0001\u0000\u0000\u0000\u001a\u00b8\u0001\u0000\u0000\u0000"+
		"\u001c\u00bb\u0001\u0000\u0000\u0000\u001e\u00c5\u0001\u0000\u0000\u0000"+
		" \u00c7\u0001\u0000\u0000\u0000\"\u00cb\u0001\u0000\u0000\u0000$\u00d1"+
		"\u0001\u0000\u0000\u0000&\u00d3\u0001\u0000\u0000\u0000(\u00dc\u0001\u0000"+
		"\u0000\u0000*\u0107\u0001\u0000\u0000\u0000,\u0117\u0001\u0000\u0000\u0000"+
		".\u011d\u0001\u0000\u0000\u00000\u0135\u0001\u0000\u0000\u00002\u013e"+
		"\u0001\u0000\u0000\u00004\u0156\u0001\u0000\u0000\u00006\u0160\u0001\u0000"+
		"\u0000\u00008\u0164\u0001\u0000\u0000\u0000:\u0176\u0001\u0000\u0000\u0000"+
		"<\u017c\u0001\u0000\u0000\u0000>\u017e\u0001\u0000\u0000\u0000@B\u0003"+
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
		"\u0000\u0000\u0000e\t\u0001\u0000\u0000\u0000fg\u0005)\u0000\u0000gh\u0003"+
		"*\u0015\u0000h\u000b\u0001\u0000\u0000\u0000ik\u0003\b\u0004\u0000ji\u0001"+
		"\u0000\u0000\u0000jk\u0001\u0000\u0000\u0000kl\u0001\u0000\u0000\u0000"+
		"lm\u0005\u001b\u0000\u0000mn\u0005)\u0000\u0000nt\u00056\u0000\u0000o"+
		"p\u0003\n\u0005\u0000pq\u0005\u0002\u0000\u0000qs\u0001\u0000\u0000\u0000"+
		"ro\u0001\u0000\u0000\u0000sv\u0001\u0000\u0000\u0000tr\u0001\u0000\u0000"+
		"\u0000tu\u0001\u0000\u0000\u0000u{\u0001\u0000\u0000\u0000vt\u0001\u0000"+
		"\u0000\u0000wy\u0003\n\u0005\u0000xz\u0005\u0002\u0000\u0000yx\u0001\u0000"+
		"\u0000\u0000yz\u0001\u0000\u0000\u0000z|\u0001\u0000\u0000\u0000{w\u0001"+
		"\u0000\u0000\u0000{|\u0001\u0000\u0000\u0000|}\u0001\u0000\u0000\u0000"+
		"}~\u00057\u0000\u0000~\r\u0001\u0000\u0000\u0000\u007f\u0081\u0005\"\u0000"+
		"\u0000\u0080\u007f\u0001\u0000\u0000\u0000\u0080\u0081\u0001\u0000\u0000"+
		"\u0000\u0081\u0082\u0001\u0000\u0000\u0000\u0082\u0083\u0005)\u0000\u0000"+
		"\u0083\u0084\u0003*\u0015\u0000\u0084\u000f\u0001\u0000\u0000\u0000\u0085"+
		"\u0087\u0003\b\u0004\u0000\u0086\u0085\u0001\u0000\u0000\u0000\u0086\u0087"+
		"\u0001\u0000\u0000\u0000\u0087\u0088\u0001\u0000\u0000\u0000\u0088\u0089"+
		"\u0005\u0016\u0000\u0000\u0089\u008a\u0005)\u0000\u0000\u008a\u0093\u0005"+
		"4\u0000\u0000\u008b\u0090\u0003\u000e\u0007\u0000\u008c\u008d\u0005\u0002"+
		"\u0000\u0000\u008d\u008f\u0003\u000e\u0007\u0000\u008e\u008c\u0001\u0000"+
		"\u0000\u0000\u008f\u0092\u0001\u0000\u0000\u0000\u0090\u008e\u0001\u0000"+
		"\u0000\u0000\u0090\u0091\u0001\u0000\u0000\u0000\u0091\u0094\u0001\u0000"+
		"\u0000\u0000\u0092\u0090\u0001\u0000\u0000\u0000\u0093\u008b\u0001\u0000"+
		"\u0000\u0000\u0093\u0094\u0001\u0000\u0000\u0000\u0094\u0095\u0001\u0000"+
		"\u0000\u0000\u0095\u0097\u00055\u0000\u0000\u0096\u0098\u0003*\u0015\u0000"+
		"\u0097\u0096\u0001\u0000\u0000\u0000\u0097\u0098\u0001\u0000\u0000\u0000"+
		"\u0098\u0099\u0001\u0000\u0000\u0000\u0099\u009a\u0003\u0014\n\u0000\u009a"+
		"\u0011\u0001\u0000\u0000\u0000\u009b\u009c\u0005\u001a\u0000\u0000\u009c"+
		"\u009d\u0005)\u0000\u0000\u009d\u009e\u00052\u0000\u0000\u009e\u009f\u0003"+
		"*\u0015\u0000\u009f\u0013\u0001\u0000\u0000\u0000\u00a0\u00a4\u00056\u0000"+
		"\u0000\u00a1\u00a3\u0003\u0016\u000b\u0000\u00a2\u00a1\u0001\u0000\u0000"+
		"\u0000\u00a3\u00a6\u0001\u0000\u0000\u0000\u00a4\u00a2\u0001\u0000\u0000"+
		"\u0000\u00a4\u00a5\u0001\u0000\u0000\u0000\u00a5\u00a7\u0001\u0000\u0000"+
		"\u0000\u00a6\u00a4\u0001\u0000\u0000\u0000\u00a7\u00a8\u00057\u0000\u0000"+
		"\u00a8\u0015\u0001\u0000\u0000\u0000\u00a9\u00b4\u0003\"\u0011\u0000\u00aa"+
		"\u00b4\u0003&\u0013\u0000\u00ab\u00b4\u0003\u001c\u000e\u0000\u00ac\u00b4"+
		"\u0003 \u0010\u0000\u00ad\u00b4\u0003\u001a\r\u0000\u00ae\u00b4\u0003"+
		"\u0018\f\u0000\u00af\u00b4\u0005\u0017\u0000\u0000\u00b0\u00b4\u0005\u0018"+
		"\u0000\u0000\u00b1\u00b4\u0003\u0014\n\u0000\u00b2\u00b4\u0003,\u0016"+
		"\u0000\u00b3\u00a9\u0001\u0000\u0000\u0000\u00b3\u00aa\u0001\u0000\u0000"+
		"\u0000\u00b3\u00ab\u0001\u0000\u0000\u0000\u00b3\u00ac\u0001\u0000\u0000"+
		"\u0000\u00b3\u00ad\u0001\u0000\u0000\u0000\u00b3\u00ae\u0001\u0000\u0000"+
		"\u0000\u00b3\u00af\u0001\u0000\u0000\u0000\u00b3\u00b0\u0001\u0000\u0000"+
		"\u0000\u00b3\u00b1\u0001\u0000\u0000\u0000\u00b3\u00b2\u0001\u0000\u0000"+
		"\u0000\u00b4\u0017\u0001\u0000\u0000\u0000\u00b5\u00b6\u0005\u001e\u0000"+
		"\u0000\u00b6\u00b7\u0003,\u0016\u0000\u00b7\u0019\u0001\u0000\u0000\u0000"+
		"\u00b8\u00b9\u0005\u0019\u0000\u0000\u00b9\u00ba\u0003\u0014\n\u0000\u00ba"+
		"\u001b\u0001\u0000\u0000\u0000\u00bb\u00bc\u0005\u0013\u0000\u0000\u00bc"+
		"\u00bd\u0003,\u0016\u0000\u00bd\u00bf\u0003\u0014\n\u0000\u00be\u00c0"+
		"\u0003\u001e\u000f\u0000\u00bf\u00be\u0001\u0000\u0000\u0000\u00bf\u00c0"+
		"\u0001\u0000\u0000\u0000\u00c0\u001d\u0001\u0000\u0000\u0000\u00c1\u00c2"+
		"\u0005\u0014\u0000\u0000\u00c2\u00c6\u0003\u0014\n\u0000\u00c3\u00c4\u0005"+
		"\u0014\u0000\u0000\u00c4\u00c6\u0003\u001c\u000e\u0000\u00c5\u00c1\u0001"+
		"\u0000\u0000\u0000\u00c5\u00c3\u0001\u0000\u0000\u0000\u00c6\u001f\u0001"+
		"\u0000\u0000\u0000\u00c7\u00c8\u0005\u0015\u0000\u0000\u00c8\u00c9\u0003"+
		",\u0016\u0000\u00c9\u00ca\u0003\u0014\n\u0000\u00ca!\u0001\u0000\u0000"+
		"\u0000\u00cb\u00cc\u0003,\u0016\u0000\u00cc\u00cd\u00052\u0000\u0000\u00cd"+
		"\u00ce\u0003,\u0016\u0000\u00ce#\u0001\u0000\u0000\u0000\u00cf\u00d2\u0005"+
		"(\u0000\u0000\u00d0\u00d2\u0003,\u0016\u0000\u00d1\u00cf\u0001\u0000\u0000"+
		"\u0000\u00d1\u00d0\u0001\u0000\u0000\u0000\u00d2%\u0001\u0000\u0000\u0000"+
		"\u00d3\u00d4\u0007\u0000\u0000\u0000\u00d4\u00d6\u0005)\u0000\u0000\u00d5"+
		"\u00d7\u0003*\u0015\u0000\u00d6\u00d5\u0001\u0000\u0000\u0000\u00d6\u00d7"+
		"\u0001\u0000\u0000\u0000\u00d7\u00d8\u0001\u0000\u0000\u0000\u00d8\u00d9"+
		"\u00052\u0000\u0000\u00d9\u00da\u0003$\u0012\u0000\u00da\'\u0001\u0000"+
		"\u0000\u0000\u00db\u00dd\u0005)\u0000\u0000\u00dc\u00db\u0001\u0000\u0000"+
		"\u0000\u00dc\u00dd\u0001\u0000\u0000\u0000\u00dd\u00de\u0001\u0000\u0000"+
		"\u0000\u00de\u00df\u0003*\u0015\u0000\u00df)\u0001\u0000\u0000\u0000\u00e0"+
		"\u00e1\u0006\u0015\uffff\uffff\u0000\u00e1\u0108\u0005)\u0000\u0000\u00e2"+
		"\u00e3\u00054\u0000\u0000\u00e3\u00e4\u0003*\u0015\u0000\u00e4\u00e5\u0005"+
		"5\u0000\u0000\u00e5\u0108\u0001\u0000\u0000\u0000\u00e6\u00e9\u0005)\u0000"+
		"\u0000\u00e7\u00e8\u0005\u0001\u0000\u0000\u00e8\u00ea\u0005)\u0000\u0000"+
		"\u00e9\u00e7\u0001\u0000\u0000\u0000\u00ea\u00eb\u0001\u0000\u0000\u0000"+
		"\u00eb\u00e9\u0001\u0000\u0000\u0000\u00eb\u00ec\u0001\u0000\u0000\u0000"+
		"\u00ec\u0108\u0001\u0000\u0000\u0000\u00ed\u00ee\u0005/\u0000\u0000\u00ee"+
		"\u0108\u0003*\u0015\u0003\u00ef\u00f0\u00058\u0000\u0000\u00f0\u00f3\u0003"+
		"*\u0015\u0000\u00f1\u00f2\u0005\u0004\u0000\u0000\u00f2\u00f4\u0005*\u0000"+
		"\u0000\u00f3\u00f1\u0001\u0000\u0000\u0000\u00f3\u00f4\u0001\u0000\u0000"+
		"\u0000\u00f4\u00f5\u0001\u0000\u0000\u0000\u00f5\u00f6\u00059\u0000\u0000"+
		"\u00f6\u0108\u0001\u0000\u0000\u0000\u00f7\u00f8\u0005\u0016\u0000\u0000"+
		"\u00f8\u0101\u00054\u0000\u0000\u00f9\u00fe\u0003(\u0014\u0000\u00fa\u00fb"+
		"\u0005\u0002\u0000\u0000\u00fb\u00fd\u0003(\u0014\u0000\u00fc\u00fa\u0001"+
		"\u0000\u0000\u0000\u00fd\u0100\u0001\u0000\u0000\u0000\u00fe\u00fc\u0001"+
		"\u0000\u0000\u0000\u00fe\u00ff\u0001\u0000\u0000\u0000\u00ff\u0102\u0001"+
		"\u0000\u0000\u0000\u0100\u00fe\u0001\u0000\u0000\u0000\u0101\u00f9\u0001"+
		"\u0000\u0000\u0000\u0101\u0102\u0001\u0000\u0000\u0000\u0102\u0103\u0001"+
		"\u0000\u0000\u0000\u0103\u0105\u00055\u0000\u0000\u0104\u0106\u0003*\u0015"+
		"\u0000\u0105\u0104\u0001\u0000\u0000\u0000\u0105\u0106\u0001\u0000\u0000"+
		"\u0000\u0106\u0108\u0001\u0000\u0000\u0000\u0107\u00e0\u0001\u0000\u0000"+
		"\u0000\u0107\u00e2\u0001\u0000\u0000\u0000\u0107\u00e6\u0001\u0000\u0000"+
		"\u0000\u0107\u00ed\u0001\u0000\u0000\u0000\u0107\u00ef\u0001\u0000\u0000"+
		"\u0000\u0107\u00f7\u0001\u0000\u0000\u0000\u0108\u0114\u0001\u0000\u0000"+
		"\u0000\u0109\u010a\n\u0004\u0000\u0000\u010a\u010c\u0005\u0003\u0000\u0000"+
		"\u010b\u010d\u0003*\u0015\u0000\u010c\u010b\u0001\u0000\u0000\u0000\u010d"+
		"\u010e\u0001\u0000\u0000\u0000\u010e\u010c\u0001\u0000\u0000\u0000\u010e"+
		"\u010f\u0001\u0000\u0000\u0000\u010f\u0110\u0001\u0000\u0000\u0000\u0110"+
		"\u0111\u0005\u0003\u0000\u0000\u0111\u0113\u0001\u0000\u0000\u0000\u0112"+
		"\u0109\u0001\u0000\u0000\u0000\u0113\u0116\u0001\u0000\u0000\u0000\u0114"+
		"\u0112\u0001\u0000\u0000\u0000\u0114\u0115\u0001\u0000\u0000\u0000\u0115"+
		"+\u0001\u0000\u0000\u0000\u0116\u0114\u0001\u0000\u0000\u0000\u0117\u0118"+
		"\u0003.\u0017\u0000\u0118-\u0001\u0000\u0000\u0000\u0119\u011a\u0006\u0017"+
		"\uffff\uffff\u0000\u011a\u011b\u0007\u0001\u0000\u0000\u011b\u011e\u0003"+
		".\u0017\u0003\u011c\u011e\u00032\u0019\u0000\u011d\u0119\u0001\u0000\u0000"+
		"\u0000\u011d\u011c\u0001\u0000\u0000\u0000\u011e\u0132\u0001\u0000\u0000"+
		"\u0000\u011f\u0120\n\b\u0000\u0000\u0120\u0121\u0007\u0002\u0000\u0000"+
		"\u0121\u0131\u0003.\u0017\t\u0122\u0123\n\u0007\u0000\u0000\u0123\u0124"+
		"\u0007\u0003\u0000\u0000\u0124\u0131\u0003.\u0017\b\u0125\u0126\n\u0006"+
		"\u0000\u0000\u0126\u0127\u0007\u0004\u0000\u0000\u0127\u0131\u0003.\u0017"+
		"\u0007\u0128\u0129\n\u0005\u0000\u0000\u0129\u012a\u0007\u0005\u0000\u0000"+
		"\u012a\u0131\u0003.\u0017\u0006\u012b\u012c\n\u0004\u0000\u0000\u012c"+
		"\u012d\u0007\u0006\u0000\u0000\u012d\u0131\u0003.\u0017\u0005\u012e\u012f"+
		"\n\u0002\u0000\u0000\u012f\u0131\u0007\u0007\u0000\u0000\u0130\u011f\u0001"+
		"\u0000\u0000\u0000\u0130\u0122\u0001\u0000\u0000\u0000\u0130\u0125\u0001"+
		"\u0000\u0000\u0000\u0130\u0128\u0001\u0000\u0000\u0000\u0130\u012b\u0001"+
		"\u0000\u0000\u0000\u0130\u012e\u0001\u0000\u0000\u0000\u0131\u0134\u0001"+
		"\u0000\u0000\u0000\u0132\u0130\u0001\u0000\u0000\u0000\u0132\u0133\u0001"+
		"\u0000\u0000\u0000\u0133/\u0001\u0000\u0000\u0000\u0134\u0132\u0001\u0000"+
		"\u0000\u0000\u0135\u0139\u0005\u0003\u0000\u0000\u0136\u0138\u0003*\u0015"+
		"\u0000\u0137\u0136\u0001\u0000\u0000\u0000\u0138\u013b\u0001\u0000\u0000"+
		"\u0000\u0139\u0137\u0001\u0000\u0000\u0000\u0139\u013a\u0001\u0000\u0000"+
		"\u0000\u013a\u013c\u0001\u0000\u0000\u0000\u013b\u0139\u0001\u0000\u0000"+
		"\u0000\u013c\u013d\u0005\u0003\u0000\u0000\u013d1\u0001\u0000\u0000\u0000"+
		"\u013e\u013f\u0006\u0019\uffff\uffff\u0000\u013f\u0140\u00038\u001c\u0000"+
		"\u0140\u0153\u0001\u0000\u0000\u0000\u0141\u0143\n\u0002\u0000\u0000\u0142"+
		"\u0144\u00030\u0018\u0000\u0143\u0142\u0001\u0000\u0000\u0000\u0143\u0144"+
		"\u0001\u0000\u0000\u0000\u0144\u0145\u0001\u0000\u0000\u0000\u0145\u014e"+
		"\u00054\u0000\u0000\u0146\u014b\u0003,\u0016\u0000\u0147\u0148\u0005\u0002"+
		"\u0000\u0000\u0148\u014a\u0003,\u0016\u0000\u0149\u0147\u0001\u0000\u0000"+
		"\u0000\u014a\u014d\u0001\u0000\u0000\u0000\u014b\u0149\u0001\u0000\u0000"+
		"\u0000\u014b\u014c\u0001\u0000\u0000\u0000\u014c\u014f\u0001\u0000\u0000"+
		"\u0000\u014d\u014b\u0001\u0000\u0000\u0000\u014e\u0146\u0001\u0000\u0000"+
		"\u0000\u014e\u014f\u0001\u0000\u0000\u0000\u014f\u0150\u0001\u0000\u0000"+
		"\u0000\u0150\u0152\u00055\u0000\u0000\u0151\u0141\u0001\u0000\u0000\u0000"+
		"\u0152\u0155\u0001\u0000\u0000\u0000\u0153\u0151\u0001\u0000\u0000\u0000"+
		"\u0153\u0154\u0001\u0000\u0000\u0000\u01543\u0001\u0000\u0000\u0000\u0155"+
		"\u0153\u0001\u0000\u0000\u0000\u0156\u0157\u0005\u001d\u0000\u0000\u0157"+
		"\u0158\u0003*\u0015\u0000\u0158\u015a\u00056\u0000\u0000\u0159\u015b\u0003"+
		"6\u001b\u0000\u015a\u0159\u0001\u0000\u0000\u0000\u015b\u015c\u0001\u0000"+
		"\u0000\u0000\u015c\u015a\u0001\u0000\u0000\u0000\u015c\u015d\u0001\u0000"+
		"\u0000\u0000\u015d\u015e\u0001\u0000\u0000\u0000\u015e\u015f\u00057\u0000"+
		"\u0000\u015f5\u0001\u0000\u0000\u0000\u0160\u0161\u0005)\u0000\u0000\u0161"+
		"\u0162\u00052\u0000\u0000\u0162\u0163\u0003,\u0016\u0000\u01637\u0001"+
		"\u0000\u0000\u0000\u0164\u0165\u0006\u001c\uffff\uffff\u0000\u0165\u0166"+
		"\u0003:\u001d\u0000\u0166\u016c\u0001\u0000\u0000\u0000\u0167\u0168\n"+
		"\u0002\u0000\u0000\u0168\u0169\u0005\u0001\u0000\u0000\u0169\u016b\u0005"+
		")\u0000\u0000\u016a\u0167\u0001\u0000\u0000\u0000\u016b\u016e\u0001\u0000"+
		"\u0000\u0000\u016c\u016a\u0001\u0000\u0000\u0000\u016c\u016d\u0001\u0000"+
		"\u0000\u0000\u016d9\u0001\u0000\u0000\u0000\u016e\u016c\u0001\u0000\u0000"+
		"\u0000\u016f\u0177\u0003<\u001e\u0000\u0170\u0177\u0005)\u0000\u0000\u0171"+
		"\u0172\u00054\u0000\u0000\u0172\u0173\u0003,\u0016\u0000\u0173\u0174\u0005"+
		"5\u0000\u0000\u0174\u0177\u0001\u0000\u0000\u0000\u0175\u0177\u00034\u001a"+
		"\u0000\u0176\u016f\u0001\u0000\u0000\u0000\u0176\u0170\u0001\u0000\u0000"+
		"\u0000\u0176\u0171\u0001\u0000\u0000\u0000\u0176\u0175\u0001\u0000\u0000"+
		"\u0000\u0177;\u0001\u0000\u0000\u0000\u0178\u017d\u0005*\u0000\u0000\u0179"+
		"\u017d\u0005+\u0000\u0000\u017a\u017d\u0005,\u0000\u0000\u017b\u017d\u0003"+
		">\u001f\u0000\u017c\u0178\u0001\u0000\u0000\u0000\u017c\u0179\u0001\u0000"+
		"\u0000\u0000\u017c\u017a\u0001\u0000\u0000\u0000\u017c\u017b\u0001\u0000"+
		"\u0000\u0000\u017d=\u0001\u0000\u0000\u0000\u017e\u017f\u0007\b\u0000"+
		"\u0000\u017f?\u0001\u0000\u0000\u0000)CLT]djty{\u0080\u0086\u0090\u0093"+
		"\u0097\u00a4\u00b3\u00bf\u00c5\u00d1\u00d6\u00dc\u00eb\u00f3\u00fe\u0101"+
		"\u0105\u0107\u010e\u0114\u011d\u0130\u0132\u0139\u0143\u014b\u014e\u0153"+
		"\u015c\u016c\u0176\u017c";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}