// Generated from c:/Users/rafaed/Desktop/Programming/rec/source/Antlr/ReC.g4 by ANTLR 4.13.1
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
		Var=17, Let=18, End=19, If=20, Else=21, While=22, Fn=23, Continue=24, 
		Break=25, Defer=26, Type=27, Struct=28, Template=29, New=30, Return=31, 
		For=32, Mod=33, Use=34, Auto=35, And=36, Not=37, Or=38, True=39, False=40, 
		Uninit=41, As=42, Identifier=43, Integer=44, Float=45, String=46, Plus=47, 
		Minus=48, Star=49, Slash=50, Ampersand=51, Equal=52, CompEqual=53, OpenParen=54, 
		CloseParen=55, OpenBrace=56, CloseBrace=57, OpenIndex=58, CloseIndex=59;
	public static final int
		RULE_program = 0, RULE_topLevelStatement = 1, RULE_asStatement = 2, RULE_modStatement = 3, 
		RULE_useStatement = 4, RULE_templateHeader = 5, RULE_structFieldDefine = 6, 
		RULE_structDefine = 7, RULE_fnArgumentDefine = 8, RULE_fnDefine = 9, RULE_aliasDefine = 10, 
		RULE_block = 11, RULE_statement = 12, RULE_returnStmt = 13, RULE_deferStmt = 14, 
		RULE_ifStmt = 15, RULE_ifTail = 16, RULE_whileStmt = 17, RULE_assignStmt = 18, 
		RULE_letExpr = 19, RULE_letStmt = 20, RULE_typenameFnArgs = 21, RULE_typename = 22, 
		RULE_expr = 23, RULE_opExpr = 24, RULE_explicitTemplateInstatiation = 25, 
		RULE_callExpr = 26, RULE_structExpr = 27, RULE_structExprAssign = 28, 
		RULE_dotComponent = 29, RULE_dotExpr = 30, RULE_termExpr = 31, RULE_literal = 32, 
		RULE_boolLiteral = 33;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "topLevelStatement", "asStatement", "modStatement", "useStatement", 
			"templateHeader", "structFieldDefine", "structDefine", "fnArgumentDefine", 
			"fnDefine", "aliasDefine", "block", "statement", "returnStmt", "deferStmt", 
			"ifStmt", "ifTail", "whileStmt", "assignStmt", "letExpr", "letStmt", 
			"typenameFnArgs", "typename", "expr", "opExpr", "explicitTemplateInstatiation", 
			"callExpr", "structExpr", "structExprAssign", "dotComponent", "dotExpr", 
			"termExpr", "literal", "boolLiteral"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "','", "';'", "'!='", "'>'", "'<'", "'<='", "'>='", "'|'", 
			"'>>'", "'<<'", "'~'", "'''", null, null, null, "'var'", "'let'", "'end'", 
			"'if'", "'else'", "'while'", "'fn'", "'continue'", "'break'", "'defer'", 
			"'type'", "'struct'", "'template'", "'new'", "'return'", "'for'", "'mod'", 
			"'use'", "'auto'", "'and'", "'not'", "'or'", "'true'", "'false'", "'uninit'", 
			"'as'", null, null, null, null, "'+'", "'-'", "'*'", "'/'", "'&'", "'='", 
			"'=='", "'('", "')'", "'{'", "'}'", "'['", "']'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, "Whitespace", "SLComment", "MLComment", "Var", "Let", "End", 
			"If", "Else", "While", "Fn", "Continue", "Break", "Defer", "Type", "Struct", 
			"Template", "New", "Return", "For", "Mod", "Use", "Auto", "And", "Not", 
			"Or", "True", "False", "Uninit", "As", "Identifier", "Integer", "Float", 
			"String", "Plus", "Minus", "Star", "Slash", "Ampersand", "Equal", "CompEqual", 
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
			setState(71);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4424764620800L) != 0)) {
				{
				{
				setState(68);
				topLevelStatement();
				}
				}
				setState(73);
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
		public AsStatementContext asStatement() {
			return getRuleContext(AsStatementContext.class,0);
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
			setState(81);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(74);
				fnDefine();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(75);
				structDefine();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(76);
				aliasDefine();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(77);
				letStmt();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(78);
				modStatement();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(79);
				asStatement();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(80);
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
	public static class AsStatementContext extends ParserRuleContext {
		public List<TerminalNode> As() { return getTokens(ReCParser.As); }
		public TerminalNode As(int i) {
			return getToken(ReCParser.As, i);
		}
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public TerminalNode End() { return getToken(ReCParser.End, 0); }
		public List<TerminalNode> Identifier() { return getTokens(ReCParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(ReCParser.Identifier, i);
		}
		public List<TopLevelStatementContext> topLevelStatement() {
			return getRuleContexts(TopLevelStatementContext.class);
		}
		public TopLevelStatementContext topLevelStatement(int i) {
			return getRuleContext(TopLevelStatementContext.class,i);
		}
		public AsStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_asStatement; }
	}

	public final AsStatementContext asStatement() throws RecognitionException {
		AsStatementContext _localctx = new AsStatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_asStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(83);
			match(As);
			setState(84);
			typename();
			setState(88);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==Identifier) {
				{
				{
				setState(85);
				match(Identifier);
				}
				}
				setState(90);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(94);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4424764620800L) != 0)) {
				{
				{
				setState(91);
				topLevelStatement();
				}
				}
				setState(96);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(97);
			match(End);
			setState(98);
			match(As);
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
		public List<TerminalNode> Mod() { return getTokens(ReCParser.Mod); }
		public TerminalNode Mod(int i) {
			return getToken(ReCParser.Mod, i);
		}
		public List<TerminalNode> Identifier() { return getTokens(ReCParser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(ReCParser.Identifier, i);
		}
		public List<TopLevelStatementContext> topLevelStatement() {
			return getRuleContexts(TopLevelStatementContext.class);
		}
		public TopLevelStatementContext topLevelStatement(int i) {
			return getRuleContext(TopLevelStatementContext.class,i);
		}
		public TerminalNode End() { return getToken(ReCParser.End, 0); }
		public ModStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_modStatement; }
	}

	public final ModStatementContext modStatement() throws RecognitionException {
		ModStatementContext _localctx = new ModStatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_modStatement);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(100);
			match(Mod);
			{
			setState(101);
			((ModStatementContext)_localctx).Identifier = match(Identifier);
			((ModStatementContext)_localctx).parts.add(((ModStatementContext)_localctx).Identifier);
			setState(106);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(102);
				match(T__0);
				setState(103);
				((ModStatementContext)_localctx).Identifier = match(Identifier);
				((ModStatementContext)_localctx).parts.add(((ModStatementContext)_localctx).Identifier);
				}
				}
				setState(108);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
			setState(112);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(109);
					topLevelStatement();
					}
					} 
				}
				setState(114);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			}
			setState(117);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				{
				setState(115);
				match(End);
				setState(116);
				match(Mod);
				}
				break;
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
		enterRule(_localctx, 8, RULE_useStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(119);
			match(Use);
			{
			setState(120);
			((UseStatementContext)_localctx).Identifier = match(Identifier);
			((UseStatementContext)_localctx).parts.add(((UseStatementContext)_localctx).Identifier);
			setState(125);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(121);
				match(T__0);
				setState(122);
				((UseStatementContext)_localctx).Identifier = match(Identifier);
				((UseStatementContext)_localctx).parts.add(((UseStatementContext)_localctx).Identifier);
				}
				}
				setState(127);
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
		enterRule(_localctx, 10, RULE_templateHeader);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(128);
			match(Template);
			setState(130); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(129);
				((TemplateHeaderContext)_localctx).Identifier = match(Identifier);
				((TemplateHeaderContext)_localctx).args.add(((TemplateHeaderContext)_localctx).Identifier);
				}
				}
				setState(132); 
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
		enterRule(_localctx, 12, RULE_structFieldDefine);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(134);
			((StructFieldDefineContext)_localctx).name = match(Identifier);
			setState(135);
			((StructFieldDefineContext)_localctx).type = typename();
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
		enterRule(_localctx, 14, RULE_structDefine);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(138);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Template) {
				{
				setState(137);
				templateHeader();
				}
			}

			setState(140);
			match(Struct);
			setState(141);
			((StructDefineContext)_localctx).name = match(Identifier);
			setState(142);
			match(OpenBrace);
			setState(148);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(143);
					((StructDefineContext)_localctx).structFieldDefine = structFieldDefine();
					((StructDefineContext)_localctx).fields.add(((StructDefineContext)_localctx).structFieldDefine);
					setState(144);
					match(T__1);
					}
					} 
				}
				setState(150);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			}
			setState(155);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Identifier) {
				{
				setState(151);
				((StructDefineContext)_localctx).structFieldDefine = structFieldDefine();
				((StructDefineContext)_localctx).fields.add(((StructDefineContext)_localctx).structFieldDefine);
				setState(153);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__1) {
					{
					setState(152);
					match(T__1);
					}
				}

				}
			}

			setState(157);
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
		enterRule(_localctx, 16, RULE_fnArgumentDefine);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(160);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Auto) {
				{
				setState(159);
				((FnArgumentDefineContext)_localctx).auto = match(Auto);
				}
			}

			setState(162);
			match(Identifier);
			setState(163);
			typename();
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
		enterRule(_localctx, 18, RULE_fnDefine);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Template) {
				{
				setState(165);
				templateHeader();
				}
			}

			setState(168);
			match(Fn);
			setState(169);
			((FnDefineContext)_localctx).name = match(Identifier);
			setState(170);
			match(OpenParen);
			setState(179);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Auto || _la==Identifier) {
				{
				setState(171);
				((FnDefineContext)_localctx).fnArgumentDefine = fnArgumentDefine();
				((FnDefineContext)_localctx).args.add(((FnDefineContext)_localctx).fnArgumentDefine);
				setState(176);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__1) {
					{
					{
					setState(172);
					match(T__1);
					setState(173);
					((FnDefineContext)_localctx).fnArgumentDefine = fnArgumentDefine();
					((FnDefineContext)_localctx).args.add(((FnDefineContext)_localctx).fnArgumentDefine);
					}
					}
					setState(178);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(181);
			match(CloseParen);
			setState(183);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 306816520716025856L) != 0)) {
				{
				setState(182);
				((FnDefineContext)_localctx).ret = typename();
				}
			}

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
		enterRule(_localctx, 20, RULE_aliasDefine);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(187);
			match(Type);
			setState(188);
			((AliasDefineContext)_localctx).name = match(Identifier);
			setState(189);
			match(Equal);
			setState(190);
			typename();
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
		enterRule(_localctx, 22, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
			match(OpenBrace);
			setState(196);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 90627936458510336L) != 0)) {
				{
				{
				setState(193);
				((BlockContext)_localctx).statement = statement();
				((BlockContext)_localctx).stmts.add(((BlockContext)_localctx).statement);
				}
				}
				setState(198);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(199);
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
		enterRule(_localctx, 24, RULE_statement);
		try {
			setState(211);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(201);
				assignStmt();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(202);
				letStmt();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(203);
				ifStmt();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(204);
				whileStmt();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(205);
				deferStmt();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(206);
				returnStmt();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(207);
				match(Continue);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(208);
				match(Break);
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(209);
				block();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(210);
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
		enterRule(_localctx, 26, RULE_returnStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(213);
			match(Return);
			setState(214);
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
		enterRule(_localctx, 28, RULE_deferStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(216);
			match(Defer);
			setState(217);
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
		enterRule(_localctx, 30, RULE_ifStmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(219);
			match(If);
			setState(220);
			((IfStmtContext)_localctx).cond = expr();
			setState(221);
			block();
			setState(223);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==Else) {
				{
				setState(222);
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
		enterRule(_localctx, 32, RULE_ifTail);
		try {
			setState(229);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(225);
				match(Else);
				setState(226);
				((IfTailContext)_localctx).end_block = block();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(227);
				match(Else);
				setState(228);
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
		enterRule(_localctx, 34, RULE_whileStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(231);
			match(While);
			setState(232);
			((WhileStmtContext)_localctx).cond = expr();
			setState(233);
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
		enterRule(_localctx, 36, RULE_assignStmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(235);
			((AssignStmtContext)_localctx).target = expr();
			setState(236);
			match(Equal);
			setState(237);
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
		enterRule(_localctx, 38, RULE_letExpr);
		try {
			setState(241);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case Uninit:
				enterOuterAlt(_localctx, 1);
				{
				setState(239);
				match(Uninit);
				}
				break;
			case T__11:
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
				setState(240);
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
		enterRule(_localctx, 40, RULE_letStmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(243);
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
			setState(244);
			((LetStmtContext)_localctx).target = match(Identifier);
			setState(246);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 306816520716025856L) != 0)) {
				{
				setState(245);
				((LetStmtContext)_localctx).type = typename();
				}
			}

			setState(248);
			match(Equal);
			setState(249);
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
		enterRule(_localctx, 42, RULE_typenameFnArgs);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(252);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				{
				setState(251);
				match(Identifier);
				}
				break;
			}
			setState(254);
			((TypenameFnArgsContext)_localctx).type = typename();
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
		public TerminalNode OpenParen() { return getToken(ReCParser.OpenParen, 0); }
		public TerminalNode CloseParen() { return getToken(ReCParser.CloseParen, 0); }
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
		TypenameContext _localctx = new TypenameContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_typename);
		int _la;
		try {
			int _alt;
			setState(303);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,31,_ctx) ) {
			case 1:
				_localctx = new TypenameSingleContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(256);
				match(Identifier);
				}
				break;
			case 2:
				_localctx = new TypenameSingleContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(257);
				match(OpenParen);
				setState(258);
				((TypenameSingleContext)_localctx).inner = typename();
				setState(259);
				match(CloseParen);
				}
				break;
			case 3:
				_localctx = new TypenameManyContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(261);
				((TypenameManyContext)_localctx).Identifier = match(Identifier);
				((TypenameManyContext)_localctx).parts.add(((TypenameManyContext)_localctx).Identifier);
				setState(264); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(262);
						match(T__0);
						setState(263);
						((TypenameManyContext)_localctx).Identifier = match(Identifier);
						((TypenameManyContext)_localctx).parts.add(((TypenameManyContext)_localctx).Identifier);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(266); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			case 4:
				_localctx = new TypenameGenericContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(268);
				match(OpenParen);
				setState(269);
				((TypenameGenericContext)_localctx).base = typename();
				setState(271); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(270);
					((TypenameGenericContext)_localctx).typename = typename();
					((TypenameGenericContext)_localctx).args.add(((TypenameGenericContext)_localctx).typename);
					}
					}
					setState(273); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 306816520716025856L) != 0) );
				setState(275);
				match(CloseParen);
				}
				break;
			case 5:
				_localctx = new TypenamePointerContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(277);
				match(Star);
				setState(278);
				((TypenamePointerContext)_localctx).base = typename();
				}
				break;
			case 6:
				_localctx = new TypenameArrayContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(279);
				match(OpenIndex);
				setState(280);
				((TypenameArrayContext)_localctx).base = typename();
				setState(283);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__2) {
					{
					setState(281);
					match(T__2);
					setState(282);
					((TypenameArrayContext)_localctx).count = match(Integer);
					}
				}

				setState(285);
				match(CloseIndex);
				}
				break;
			case 7:
				_localctx = new TypenameFnContext(_localctx);
				enterOuterAlt(_localctx, 7);
				{
				setState(287);
				match(Fn);
				setState(288);
				match(OpenParen);
				setState(297);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 306816520716025856L) != 0)) {
					{
					setState(289);
					((TypenameFnContext)_localctx).typenameFnArgs = typenameFnArgs();
					((TypenameFnContext)_localctx).args.add(((TypenameFnContext)_localctx).typenameFnArgs);
					setState(294);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==T__1) {
						{
						{
						setState(290);
						match(T__1);
						setState(291);
						((TypenameFnContext)_localctx).typenameFnArgs = typenameFnArgs();
						((TypenameFnContext)_localctx).args.add(((TypenameFnContext)_localctx).typenameFnArgs);
						}
						}
						setState(296);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(299);
				match(CloseParen);
				setState(301);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
				case 1:
					{
					setState(300);
					((TypenameFnContext)_localctx).ret = typename();
					}
					break;
				}
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
		enterRule(_localctx, 46, RULE_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(305);
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
		int _startState = 48;
		enterRecursionRule(_localctx, 48, RULE_opExpr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(311);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__11:
			case Not:
			case Plus:
			case Minus:
				{
				_localctx = new UnaryExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(308);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 422349904023552L) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(309);
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
				setState(310);
				callExpr(0);
				}
				break;
			default:
				throw new NoViableAltException(this);
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
					setState(330);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
					case 1:
						{
						_localctx = new LogicExpressionContext(new OpExprContext(_parentctx, _parentState));
						((LogicExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(313);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(314);
						_la = _input.LA(1);
						if ( !(_la==And || _la==Or) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(315);
						((LogicExpressionContext)_localctx).lhs = opExpr(9);
						}
						break;
					case 2:
						{
						_localctx = new CompareExpressionContext(new OpExprContext(_parentctx, _parentState));
						((CompareExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(316);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(317);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 9007199254741488L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(318);
						((CompareExpressionContext)_localctx).lhs = opExpr(8);
						}
						break;
					case 3:
						{
						_localctx = new MulExpressionContext(new OpExprContext(_parentctx, _parentState));
						((MulExpressionContext)_localctx).lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(319);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(320);
						_la = _input.LA(1);
						if ( !(_la==Star || _la==Slash) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(321);
						((MulExpressionContext)_localctx).lhs = opExpr(7);
						}
						break;
					case 4:
						{
						_localctx = new BitwiseExpressionContext(new OpExprContext(_parentctx, _parentState));
						((BitwiseExpressionContext)_localctx).rhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(322);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(323);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 2251799813688832L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(324);
						((BitwiseExpressionContext)_localctx).rhs = opExpr(6);
						}
						break;
					case 5:
						{
						_localctx = new AddExpressionContext(new OpExprContext(_parentctx, _parentState));
						((AddExpressionContext)_localctx).rhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(325);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(326);
						_la = _input.LA(1);
						if ( !(_la==Plus || _la==Minus) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(327);
						((AddExpressionContext)_localctx).rhs = opExpr(5);
						}
						break;
					case 6:
						{
						_localctx = new MemoryExpressionContext(new OpExprContext(_parentctx, _parentState));
						((MemoryExpressionContext)_localctx).op = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_opExpr);
						setState(328);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(329);
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
		enterRule(_localctx, 50, RULE_explicitTemplateInstatiation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(335);
			match(T__12);
			setState(339);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 306816520716025856L) != 0)) {
				{
				{
				setState(336);
				((ExplicitTemplateInstatiationContext)_localctx).typename = typename();
				((ExplicitTemplateInstatiationContext)_localctx).args.add(((ExplicitTemplateInstatiationContext)_localctx).typename);
				}
				}
				setState(341);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(342);
			match(T__12);
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
		int _startState = 52;
		enterRecursionRule(_localctx, 52, RULE_callExpr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(345);
			dotExpr(0);
			}
			_ctx.stop = _input.LT(-1);
			setState(365);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,39,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new CallExprContext(_parentctx, _parentState);
					_localctx.target = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_callExpr);
					setState(347);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(349);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==T__12) {
						{
						setState(348);
						((CallExprContext)_localctx).inst = explicitTemplateInstatiation();
						}
					}

					setState(351);
					match(OpenParen);
					setState(360);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 18570340150022144L) != 0)) {
						{
						setState(352);
						((CallExprContext)_localctx).expr = expr();
						((CallExprContext)_localctx).args.add(((CallExprContext)_localctx).expr);
						setState(357);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==T__1) {
							{
							{
							setState(353);
							match(T__1);
							setState(354);
							((CallExprContext)_localctx).expr = expr();
							((CallExprContext)_localctx).args.add(((CallExprContext)_localctx).expr);
							}
							}
							setState(359);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						}
					}

					setState(362);
					match(CloseParen);
					}
					} 
				}
				setState(367);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,39,_ctx);
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
		enterRule(_localctx, 54, RULE_structExpr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(368);
			match(New);
			setState(369);
			typename();
			setState(370);
			match(OpenBrace);
			setState(372); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(371);
				((StructExprContext)_localctx).structExprAssign = structExprAssign();
				((StructExprContext)_localctx).parts.add(((StructExprContext)_localctx).structExprAssign);
				}
				}
				setState(374); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==Identifier );
			setState(376);
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
		enterRule(_localctx, 56, RULE_structExprAssign);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(378);
			((StructExprAssignContext)_localctx).Field = match(Identifier);
			setState(379);
			match(Equal);
			setState(380);
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
	public static class DotComponentContext extends ParserRuleContext {
		public TerminalNode Identifier() { return getToken(ReCParser.Identifier, 0); }
		public TerminalNode As() { return getToken(ReCParser.As, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public DotComponentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_dotComponent; }
	}

	public final DotComponentContext dotComponent() throws RecognitionException {
		DotComponentContext _localctx = new DotComponentContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_dotComponent);
		try {
			setState(386);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,41,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(382);
				match(Identifier);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(383);
				match(Identifier);
				setState(384);
				match(As);
				setState(385);
				typename();
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
	public static class DotExprContext extends ParserRuleContext {
		public DotComponentContext Field;
		public TermExprContext termExpr() {
			return getRuleContext(TermExprContext.class,0);
		}
		public DotExprContext dotExpr() {
			return getRuleContext(DotExprContext.class,0);
		}
		public DotComponentContext dotComponent() {
			return getRuleContext(DotComponentContext.class,0);
		}
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
		int _startState = 60;
		enterRecursionRule(_localctx, 60, RULE_dotExpr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(389);
			termExpr();
			}
			_ctx.stop = _input.LT(-1);
			setState(396);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new DotExprContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_dotExpr);
					setState(391);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(392);
					match(T__0);
					setState(393);
					((DotExprContext)_localctx).Field = dotComponent();
					}
					} 
				}
				setState(398);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
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
		public TerminalNode As() { return getToken(ReCParser.As, 0); }
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
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
		enterRule(_localctx, 62, RULE_termExpr);
		try {
			setState(409);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,43,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(399);
				literal();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(400);
				match(Identifier);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(401);
				match(Identifier);
				setState(402);
				match(As);
				setState(403);
				typename();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(404);
				match(OpenParen);
				setState(405);
				expr();
				setState(406);
				match(CloseParen);
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(408);
				structExpr();
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
		enterRule(_localctx, 64, RULE_literal);
		try {
			setState(415);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case Integer:
				enterOuterAlt(_localctx, 1);
				{
				setState(411);
				match(Integer);
				}
				break;
			case Float:
				enterOuterAlt(_localctx, 2);
				{
				setState(412);
				match(Float);
				}
				break;
			case String:
				enterOuterAlt(_localctx, 3);
				{
				setState(413);
				match(String);
				}
				break;
			case True:
			case False:
				enterOuterAlt(_localctx, 4);
				{
				setState(414);
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
		enterRule(_localctx, 66, RULE_boolLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(417);
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
		case 24:
			return opExpr_sempred((OpExprContext)_localctx, predIndex);
		case 26:
			return callExpr_sempred((CallExprContext)_localctx, predIndex);
		case 30:
			return dotExpr_sempred((DotExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean opExpr_sempred(OpExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 8);
		case 1:
			return precpred(_ctx, 7);
		case 2:
			return precpred(_ctx, 6);
		case 3:
			return precpred(_ctx, 5);
		case 4:
			return precpred(_ctx, 4);
		case 5:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean callExpr_sempred(CallExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 6:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean dotExpr_sempred(DotExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 7:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001;\u01a4\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0002 \u0007 \u0002!\u0007!\u0001\u0000\u0005"+
		"\u0000F\b\u0000\n\u0000\f\u0000I\t\u0000\u0001\u0001\u0001\u0001\u0001"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0003\u0001R\b"+
		"\u0001\u0001\u0002\u0001\u0002\u0001\u0002\u0005\u0002W\b\u0002\n\u0002"+
		"\f\u0002Z\t\u0002\u0001\u0002\u0005\u0002]\b\u0002\n\u0002\f\u0002`\t"+
		"\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0001"+
		"\u0003\u0001\u0003\u0005\u0003i\b\u0003\n\u0003\f\u0003l\t\u0003\u0001"+
		"\u0003\u0005\u0003o\b\u0003\n\u0003\f\u0003r\t\u0003\u0001\u0003\u0001"+
		"\u0003\u0003\u0003v\b\u0003\u0001\u0004\u0001\u0004\u0001\u0004\u0001"+
		"\u0004\u0005\u0004|\b\u0004\n\u0004\f\u0004\u007f\t\u0004\u0001\u0005"+
		"\u0001\u0005\u0004\u0005\u0083\b\u0005\u000b\u0005\f\u0005\u0084\u0001"+
		"\u0006\u0001\u0006\u0001\u0006\u0001\u0007\u0003\u0007\u008b\b\u0007\u0001"+
		"\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0005"+
		"\u0007\u0093\b\u0007\n\u0007\f\u0007\u0096\t\u0007\u0001\u0007\u0001\u0007"+
		"\u0003\u0007\u009a\b\u0007\u0003\u0007\u009c\b\u0007\u0001\u0007\u0001"+
		"\u0007\u0001\b\u0003\b\u00a1\b\b\u0001\b\u0001\b\u0001\b\u0001\t\u0003"+
		"\t\u00a7\b\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0005\t\u00af"+
		"\b\t\n\t\f\t\u00b2\t\t\u0003\t\u00b4\b\t\u0001\t\u0001\t\u0003\t\u00b8"+
		"\b\t\u0001\t\u0001\t\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\u000b"+
		"\u0001\u000b\u0005\u000b\u00c3\b\u000b\n\u000b\f\u000b\u00c6\t\u000b\u0001"+
		"\u000b\u0001\u000b\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001"+
		"\f\u0001\f\u0001\f\u0001\f\u0003\f\u00d4\b\f\u0001\r\u0001\r\u0001\r\u0001"+
		"\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0003\u000f\u00e0\b\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001"+
		"\u0010\u0003\u0010\u00e6\b\u0010\u0001\u0011\u0001\u0011\u0001\u0011\u0001"+
		"\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0013\u0001"+
		"\u0013\u0003\u0013\u00f2\b\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0003"+
		"\u0014\u00f7\b\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0015\u0003"+
		"\u0015\u00fd\b\u0015\u0001\u0015\u0001\u0015\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0004"+
		"\u0016\u0109\b\u0016\u000b\u0016\f\u0016\u010a\u0001\u0016\u0001\u0016"+
		"\u0001\u0016\u0004\u0016\u0110\b\u0016\u000b\u0016\f\u0016\u0111\u0001"+
		"\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0001\u0016\u0003\u0016\u011c\b\u0016\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0005\u0016\u0125"+
		"\b\u0016\n\u0016\f\u0016\u0128\t\u0016\u0003\u0016\u012a\b\u0016\u0001"+
		"\u0016\u0001\u0016\u0003\u0016\u012e\b\u0016\u0003\u0016\u0130\b\u0016"+
		"\u0001\u0017\u0001\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018"+
		"\u0003\u0018\u0138\b\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018"+
		"\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018"+
		"\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018"+
		"\u0001\u0018\u0005\u0018\u014b\b\u0018\n\u0018\f\u0018\u014e\t\u0018\u0001"+
		"\u0019\u0001\u0019\u0005\u0019\u0152\b\u0019\n\u0019\f\u0019\u0155\t\u0019"+
		"\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a"+
		"\u0001\u001a\u0003\u001a\u015e\b\u001a\u0001\u001a\u0001\u001a\u0001\u001a"+
		"\u0001\u001a\u0005\u001a\u0164\b\u001a\n\u001a\f\u001a\u0167\t\u001a\u0003"+
		"\u001a\u0169\b\u001a\u0001\u001a\u0005\u001a\u016c\b\u001a\n\u001a\f\u001a"+
		"\u016f\t\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0004\u001b"+
		"\u0175\b\u001b\u000b\u001b\f\u001b\u0176\u0001\u001b\u0001\u001b\u0001"+
		"\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001d\u0001\u001d\u0001"+
		"\u001d\u0001\u001d\u0003\u001d\u0183\b\u001d\u0001\u001e\u0001\u001e\u0001"+
		"\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0005\u001e\u018b\b\u001e\n"+
		"\u001e\f\u001e\u018e\t\u001e\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0003\u001f\u019a\b\u001f\u0001 \u0001 \u0001 \u0001 \u0003 \u01a0"+
		"\b \u0001!\u0001!\u0001!\u0000\u000304<\"\u0000\u0002\u0004\u0006\b\n"+
		"\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e \"$&(*,.0246"+
		"8:<>@B\u0000\t\u0001\u0000\u0011\u0012\u0003\u0000\f\f%%/0\u0002\u0000"+
		"$$&&\u0002\u0000\u0004\b55\u0001\u000012\u0002\u0000\t\u000b33\u0001\u0000"+
		"/0\u0002\u00001133\u0001\u0000\'(\u01c9\u0000G\u0001\u0000\u0000\u0000"+
		"\u0002Q\u0001\u0000\u0000\u0000\u0004S\u0001\u0000\u0000\u0000\u0006d"+
		"\u0001\u0000\u0000\u0000\bw\u0001\u0000\u0000\u0000\n\u0080\u0001\u0000"+
		"\u0000\u0000\f\u0086\u0001\u0000\u0000\u0000\u000e\u008a\u0001\u0000\u0000"+
		"\u0000\u0010\u00a0\u0001\u0000\u0000\u0000\u0012\u00a6\u0001\u0000\u0000"+
		"\u0000\u0014\u00bb\u0001\u0000\u0000\u0000\u0016\u00c0\u0001\u0000\u0000"+
		"\u0000\u0018\u00d3\u0001\u0000\u0000\u0000\u001a\u00d5\u0001\u0000\u0000"+
		"\u0000\u001c\u00d8\u0001\u0000\u0000\u0000\u001e\u00db\u0001\u0000\u0000"+
		"\u0000 \u00e5\u0001\u0000\u0000\u0000\"\u00e7\u0001\u0000\u0000\u0000"+
		"$\u00eb\u0001\u0000\u0000\u0000&\u00f1\u0001\u0000\u0000\u0000(\u00f3"+
		"\u0001\u0000\u0000\u0000*\u00fc\u0001\u0000\u0000\u0000,\u012f\u0001\u0000"+
		"\u0000\u0000.\u0131\u0001\u0000\u0000\u00000\u0137\u0001\u0000\u0000\u0000"+
		"2\u014f\u0001\u0000\u0000\u00004\u0158\u0001\u0000\u0000\u00006\u0170"+
		"\u0001\u0000\u0000\u00008\u017a\u0001\u0000\u0000\u0000:\u0182\u0001\u0000"+
		"\u0000\u0000<\u0184\u0001\u0000\u0000\u0000>\u0199\u0001\u0000\u0000\u0000"+
		"@\u019f\u0001\u0000\u0000\u0000B\u01a1\u0001\u0000\u0000\u0000DF\u0003"+
		"\u0002\u0001\u0000ED\u0001\u0000\u0000\u0000FI\u0001\u0000\u0000\u0000"+
		"GE\u0001\u0000\u0000\u0000GH\u0001\u0000\u0000\u0000H\u0001\u0001\u0000"+
		"\u0000\u0000IG\u0001\u0000\u0000\u0000JR\u0003\u0012\t\u0000KR\u0003\u000e"+
		"\u0007\u0000LR\u0003\u0014\n\u0000MR\u0003(\u0014\u0000NR\u0003\u0006"+
		"\u0003\u0000OR\u0003\u0004\u0002\u0000PR\u0003\b\u0004\u0000QJ\u0001\u0000"+
		"\u0000\u0000QK\u0001\u0000\u0000\u0000QL\u0001\u0000\u0000\u0000QM\u0001"+
		"\u0000\u0000\u0000QN\u0001\u0000\u0000\u0000QO\u0001\u0000\u0000\u0000"+
		"QP\u0001\u0000\u0000\u0000R\u0003\u0001\u0000\u0000\u0000ST\u0005*\u0000"+
		"\u0000TX\u0003,\u0016\u0000UW\u0005+\u0000\u0000VU\u0001\u0000\u0000\u0000"+
		"WZ\u0001\u0000\u0000\u0000XV\u0001\u0000\u0000\u0000XY\u0001\u0000\u0000"+
		"\u0000Y^\u0001\u0000\u0000\u0000ZX\u0001\u0000\u0000\u0000[]\u0003\u0002"+
		"\u0001\u0000\\[\u0001\u0000\u0000\u0000]`\u0001\u0000\u0000\u0000^\\\u0001"+
		"\u0000\u0000\u0000^_\u0001\u0000\u0000\u0000_a\u0001\u0000\u0000\u0000"+
		"`^\u0001\u0000\u0000\u0000ab\u0005\u0013\u0000\u0000bc\u0005*\u0000\u0000"+
		"c\u0005\u0001\u0000\u0000\u0000de\u0005!\u0000\u0000ej\u0005+\u0000\u0000"+
		"fg\u0005\u0001\u0000\u0000gi\u0005+\u0000\u0000hf\u0001\u0000\u0000\u0000"+
		"il\u0001\u0000\u0000\u0000jh\u0001\u0000\u0000\u0000jk\u0001\u0000\u0000"+
		"\u0000kp\u0001\u0000\u0000\u0000lj\u0001\u0000\u0000\u0000mo\u0003\u0002"+
		"\u0001\u0000nm\u0001\u0000\u0000\u0000or\u0001\u0000\u0000\u0000pn\u0001"+
		"\u0000\u0000\u0000pq\u0001\u0000\u0000\u0000qu\u0001\u0000\u0000\u0000"+
		"rp\u0001\u0000\u0000\u0000st\u0005\u0013\u0000\u0000tv\u0005!\u0000\u0000"+
		"us\u0001\u0000\u0000\u0000uv\u0001\u0000\u0000\u0000v\u0007\u0001\u0000"+
		"\u0000\u0000wx\u0005\"\u0000\u0000x}\u0005+\u0000\u0000yz\u0005\u0001"+
		"\u0000\u0000z|\u0005+\u0000\u0000{y\u0001\u0000\u0000\u0000|\u007f\u0001"+
		"\u0000\u0000\u0000}{\u0001\u0000\u0000\u0000}~\u0001\u0000\u0000\u0000"+
		"~\t\u0001\u0000\u0000\u0000\u007f}\u0001\u0000\u0000\u0000\u0080\u0082"+
		"\u0005\u001d\u0000\u0000\u0081\u0083\u0005+\u0000\u0000\u0082\u0081\u0001"+
		"\u0000\u0000\u0000\u0083\u0084\u0001\u0000\u0000\u0000\u0084\u0082\u0001"+
		"\u0000\u0000\u0000\u0084\u0085\u0001\u0000\u0000\u0000\u0085\u000b\u0001"+
		"\u0000\u0000\u0000\u0086\u0087\u0005+\u0000\u0000\u0087\u0088\u0003,\u0016"+
		"\u0000\u0088\r\u0001\u0000\u0000\u0000\u0089\u008b\u0003\n\u0005\u0000"+
		"\u008a\u0089\u0001\u0000\u0000\u0000\u008a\u008b\u0001\u0000\u0000\u0000"+
		"\u008b\u008c\u0001\u0000\u0000\u0000\u008c\u008d\u0005\u001c\u0000\u0000"+
		"\u008d\u008e\u0005+\u0000\u0000\u008e\u0094\u00058\u0000\u0000\u008f\u0090"+
		"\u0003\f\u0006\u0000\u0090\u0091\u0005\u0002\u0000\u0000\u0091\u0093\u0001"+
		"\u0000\u0000\u0000\u0092\u008f\u0001\u0000\u0000\u0000\u0093\u0096\u0001"+
		"\u0000\u0000\u0000\u0094\u0092\u0001\u0000\u0000\u0000\u0094\u0095\u0001"+
		"\u0000\u0000\u0000\u0095\u009b\u0001\u0000\u0000\u0000\u0096\u0094\u0001"+
		"\u0000\u0000\u0000\u0097\u0099\u0003\f\u0006\u0000\u0098\u009a\u0005\u0002"+
		"\u0000\u0000\u0099\u0098\u0001\u0000\u0000\u0000\u0099\u009a\u0001\u0000"+
		"\u0000\u0000\u009a\u009c\u0001\u0000\u0000\u0000\u009b\u0097\u0001\u0000"+
		"\u0000\u0000\u009b\u009c\u0001\u0000\u0000\u0000\u009c\u009d\u0001\u0000"+
		"\u0000\u0000\u009d\u009e\u00059\u0000\u0000\u009e\u000f\u0001\u0000\u0000"+
		"\u0000\u009f\u00a1\u0005#\u0000\u0000\u00a0\u009f\u0001\u0000\u0000\u0000"+
		"\u00a0\u00a1\u0001\u0000\u0000\u0000\u00a1\u00a2\u0001\u0000\u0000\u0000"+
		"\u00a2\u00a3\u0005+\u0000\u0000\u00a3\u00a4\u0003,\u0016\u0000\u00a4\u0011"+
		"\u0001\u0000\u0000\u0000\u00a5\u00a7\u0003\n\u0005\u0000\u00a6\u00a5\u0001"+
		"\u0000\u0000\u0000\u00a6\u00a7\u0001\u0000\u0000\u0000\u00a7\u00a8\u0001"+
		"\u0000\u0000\u0000\u00a8\u00a9\u0005\u0017\u0000\u0000\u00a9\u00aa\u0005"+
		"+\u0000\u0000\u00aa\u00b3\u00056\u0000\u0000\u00ab\u00b0\u0003\u0010\b"+
		"\u0000\u00ac\u00ad\u0005\u0002\u0000\u0000\u00ad\u00af\u0003\u0010\b\u0000"+
		"\u00ae\u00ac\u0001\u0000\u0000\u0000\u00af\u00b2\u0001\u0000\u0000\u0000"+
		"\u00b0\u00ae\u0001\u0000\u0000\u0000\u00b0\u00b1\u0001\u0000\u0000\u0000"+
		"\u00b1\u00b4\u0001\u0000\u0000\u0000\u00b2\u00b0\u0001\u0000\u0000\u0000"+
		"\u00b3\u00ab\u0001\u0000\u0000\u0000\u00b3\u00b4\u0001\u0000\u0000\u0000"+
		"\u00b4\u00b5\u0001\u0000\u0000\u0000\u00b5\u00b7\u00057\u0000\u0000\u00b6"+
		"\u00b8\u0003,\u0016\u0000\u00b7\u00b6\u0001\u0000\u0000\u0000\u00b7\u00b8"+
		"\u0001\u0000\u0000\u0000\u00b8\u00b9\u0001\u0000\u0000\u0000\u00b9\u00ba"+
		"\u0003\u0016\u000b\u0000\u00ba\u0013\u0001\u0000\u0000\u0000\u00bb\u00bc"+
		"\u0005\u001b\u0000\u0000\u00bc\u00bd\u0005+\u0000\u0000\u00bd\u00be\u0005"+
		"4\u0000\u0000\u00be\u00bf\u0003,\u0016\u0000\u00bf\u0015\u0001\u0000\u0000"+
		"\u0000\u00c0\u00c4\u00058\u0000\u0000\u00c1\u00c3\u0003\u0018\f\u0000"+
		"\u00c2\u00c1\u0001\u0000\u0000\u0000\u00c3\u00c6\u0001\u0000\u0000\u0000"+
		"\u00c4\u00c2\u0001\u0000\u0000\u0000\u00c4\u00c5\u0001\u0000\u0000\u0000"+
		"\u00c5\u00c7\u0001\u0000\u0000\u0000\u00c6\u00c4\u0001\u0000\u0000\u0000"+
		"\u00c7\u00c8\u00059\u0000\u0000\u00c8\u0017\u0001\u0000\u0000\u0000\u00c9"+
		"\u00d4\u0003$\u0012\u0000\u00ca\u00d4\u0003(\u0014\u0000\u00cb\u00d4\u0003"+
		"\u001e\u000f\u0000\u00cc\u00d4\u0003\"\u0011\u0000\u00cd\u00d4\u0003\u001c"+
		"\u000e\u0000\u00ce\u00d4\u0003\u001a\r\u0000\u00cf\u00d4\u0005\u0018\u0000"+
		"\u0000\u00d0\u00d4\u0005\u0019\u0000\u0000\u00d1\u00d4\u0003\u0016\u000b"+
		"\u0000\u00d2\u00d4\u0003.\u0017\u0000\u00d3\u00c9\u0001\u0000\u0000\u0000"+
		"\u00d3\u00ca\u0001\u0000\u0000\u0000\u00d3\u00cb\u0001\u0000\u0000\u0000"+
		"\u00d3\u00cc\u0001\u0000\u0000\u0000\u00d3\u00cd\u0001\u0000\u0000\u0000"+
		"\u00d3\u00ce\u0001\u0000\u0000\u0000\u00d3\u00cf\u0001\u0000\u0000\u0000"+
		"\u00d3\u00d0\u0001\u0000\u0000\u0000\u00d3\u00d1\u0001\u0000\u0000\u0000"+
		"\u00d3\u00d2\u0001\u0000\u0000\u0000\u00d4\u0019\u0001\u0000\u0000\u0000"+
		"\u00d5\u00d6\u0005\u001f\u0000\u0000\u00d6\u00d7\u0003.\u0017\u0000\u00d7"+
		"\u001b\u0001\u0000\u0000\u0000\u00d8\u00d9\u0005\u001a\u0000\u0000\u00d9"+
		"\u00da\u0003\u0016\u000b\u0000\u00da\u001d\u0001\u0000\u0000\u0000\u00db"+
		"\u00dc\u0005\u0014\u0000\u0000\u00dc\u00dd\u0003.\u0017\u0000\u00dd\u00df"+
		"\u0003\u0016\u000b\u0000\u00de\u00e0\u0003 \u0010\u0000\u00df\u00de\u0001"+
		"\u0000\u0000\u0000\u00df\u00e0\u0001\u0000\u0000\u0000\u00e0\u001f\u0001"+
		"\u0000\u0000\u0000\u00e1\u00e2\u0005\u0015\u0000\u0000\u00e2\u00e6\u0003"+
		"\u0016\u000b\u0000\u00e3\u00e4\u0005\u0015\u0000\u0000\u00e4\u00e6\u0003"+
		"\u001e\u000f\u0000\u00e5\u00e1\u0001\u0000\u0000\u0000\u00e5\u00e3\u0001"+
		"\u0000\u0000\u0000\u00e6!\u0001\u0000\u0000\u0000\u00e7\u00e8\u0005\u0016"+
		"\u0000\u0000\u00e8\u00e9\u0003.\u0017\u0000\u00e9\u00ea\u0003\u0016\u000b"+
		"\u0000\u00ea#\u0001\u0000\u0000\u0000\u00eb\u00ec\u0003.\u0017\u0000\u00ec"+
		"\u00ed\u00054\u0000\u0000\u00ed\u00ee\u0003.\u0017\u0000\u00ee%\u0001"+
		"\u0000\u0000\u0000\u00ef\u00f2\u0005)\u0000\u0000\u00f0\u00f2\u0003.\u0017"+
		"\u0000\u00f1\u00ef\u0001\u0000\u0000\u0000\u00f1\u00f0\u0001\u0000\u0000"+
		"\u0000\u00f2\'\u0001\u0000\u0000\u0000\u00f3\u00f4\u0007\u0000\u0000\u0000"+
		"\u00f4\u00f6\u0005+\u0000\u0000\u00f5\u00f7\u0003,\u0016\u0000\u00f6\u00f5"+
		"\u0001\u0000\u0000\u0000\u00f6\u00f7\u0001\u0000\u0000\u0000\u00f7\u00f8"+
		"\u0001\u0000\u0000\u0000\u00f8\u00f9\u00054\u0000\u0000\u00f9\u00fa\u0003"+
		"&\u0013\u0000\u00fa)\u0001\u0000\u0000\u0000\u00fb\u00fd\u0005+\u0000"+
		"\u0000\u00fc\u00fb\u0001\u0000\u0000\u0000\u00fc\u00fd\u0001\u0000\u0000"+
		"\u0000\u00fd\u00fe\u0001\u0000\u0000\u0000\u00fe\u00ff\u0003,\u0016\u0000"+
		"\u00ff+\u0001\u0000\u0000\u0000\u0100\u0130\u0005+\u0000\u0000\u0101\u0102"+
		"\u00056\u0000\u0000\u0102\u0103\u0003,\u0016\u0000\u0103\u0104\u00057"+
		"\u0000\u0000\u0104\u0130\u0001\u0000\u0000\u0000\u0105\u0108\u0005+\u0000"+
		"\u0000\u0106\u0107\u0005\u0001\u0000\u0000\u0107\u0109\u0005+\u0000\u0000"+
		"\u0108\u0106\u0001\u0000\u0000\u0000\u0109\u010a\u0001\u0000\u0000\u0000"+
		"\u010a\u0108\u0001\u0000\u0000\u0000\u010a\u010b\u0001\u0000\u0000\u0000"+
		"\u010b\u0130\u0001\u0000\u0000\u0000\u010c\u010d\u00056\u0000\u0000\u010d"+
		"\u010f\u0003,\u0016\u0000\u010e\u0110\u0003,\u0016\u0000\u010f\u010e\u0001"+
		"\u0000\u0000\u0000\u0110\u0111\u0001\u0000\u0000\u0000\u0111\u010f\u0001"+
		"\u0000\u0000\u0000\u0111\u0112\u0001\u0000\u0000\u0000\u0112\u0113\u0001"+
		"\u0000\u0000\u0000\u0113\u0114\u00057\u0000\u0000\u0114\u0130\u0001\u0000"+
		"\u0000\u0000\u0115\u0116\u00051\u0000\u0000\u0116\u0130\u0003,\u0016\u0000"+
		"\u0117\u0118\u0005:\u0000\u0000\u0118\u011b\u0003,\u0016\u0000\u0119\u011a"+
		"\u0005\u0003\u0000\u0000\u011a\u011c\u0005,\u0000\u0000\u011b\u0119\u0001"+
		"\u0000\u0000\u0000\u011b\u011c\u0001\u0000\u0000\u0000\u011c\u011d\u0001"+
		"\u0000\u0000\u0000\u011d\u011e\u0005;\u0000\u0000\u011e\u0130\u0001\u0000"+
		"\u0000\u0000\u011f\u0120\u0005\u0017\u0000\u0000\u0120\u0129\u00056\u0000"+
		"\u0000\u0121\u0126\u0003*\u0015\u0000\u0122\u0123\u0005\u0002\u0000\u0000"+
		"\u0123\u0125\u0003*\u0015\u0000\u0124\u0122\u0001\u0000\u0000\u0000\u0125"+
		"\u0128\u0001\u0000\u0000\u0000\u0126\u0124\u0001\u0000\u0000\u0000\u0126"+
		"\u0127\u0001\u0000\u0000\u0000\u0127\u012a\u0001\u0000\u0000\u0000\u0128"+
		"\u0126\u0001\u0000\u0000\u0000\u0129\u0121\u0001\u0000\u0000\u0000\u0129"+
		"\u012a\u0001\u0000\u0000\u0000\u012a\u012b\u0001\u0000\u0000\u0000\u012b"+
		"\u012d\u00057\u0000\u0000\u012c\u012e\u0003,\u0016\u0000\u012d\u012c\u0001"+
		"\u0000\u0000\u0000\u012d\u012e\u0001\u0000\u0000\u0000\u012e\u0130\u0001"+
		"\u0000\u0000\u0000\u012f\u0100\u0001\u0000\u0000\u0000\u012f\u0101\u0001"+
		"\u0000\u0000\u0000\u012f\u0105\u0001\u0000\u0000\u0000\u012f\u010c\u0001"+
		"\u0000\u0000\u0000\u012f\u0115\u0001\u0000\u0000\u0000\u012f\u0117\u0001"+
		"\u0000\u0000\u0000\u012f\u011f\u0001\u0000\u0000\u0000\u0130-\u0001\u0000"+
		"\u0000\u0000\u0131\u0132\u00030\u0018\u0000\u0132/\u0001\u0000\u0000\u0000"+
		"\u0133\u0134\u0006\u0018\uffff\uffff\u0000\u0134\u0135\u0007\u0001\u0000"+
		"\u0000\u0135\u0138\u00030\u0018\u0003\u0136\u0138\u00034\u001a\u0000\u0137"+
		"\u0133\u0001\u0000\u0000\u0000\u0137\u0136\u0001\u0000\u0000\u0000\u0138"+
		"\u014c\u0001\u0000\u0000\u0000\u0139\u013a\n\b\u0000\u0000\u013a\u013b"+
		"\u0007\u0002\u0000\u0000\u013b\u014b\u00030\u0018\t\u013c\u013d\n\u0007"+
		"\u0000\u0000\u013d\u013e\u0007\u0003\u0000\u0000\u013e\u014b\u00030\u0018"+
		"\b\u013f\u0140\n\u0006\u0000\u0000\u0140\u0141\u0007\u0004\u0000\u0000"+
		"\u0141\u014b\u00030\u0018\u0007\u0142\u0143\n\u0005\u0000\u0000\u0143"+
		"\u0144\u0007\u0005\u0000\u0000\u0144\u014b\u00030\u0018\u0006\u0145\u0146"+
		"\n\u0004\u0000\u0000\u0146\u0147\u0007\u0006\u0000\u0000\u0147\u014b\u0003"+
		"0\u0018\u0005\u0148\u0149\n\u0002\u0000\u0000\u0149\u014b\u0007\u0007"+
		"\u0000\u0000\u014a\u0139\u0001\u0000\u0000\u0000\u014a\u013c\u0001\u0000"+
		"\u0000\u0000\u014a\u013f\u0001\u0000\u0000\u0000\u014a\u0142\u0001\u0000"+
		"\u0000\u0000\u014a\u0145\u0001\u0000\u0000\u0000\u014a\u0148\u0001\u0000"+
		"\u0000\u0000\u014b\u014e\u0001\u0000\u0000\u0000\u014c\u014a\u0001\u0000"+
		"\u0000\u0000\u014c\u014d\u0001\u0000\u0000\u0000\u014d1\u0001\u0000\u0000"+
		"\u0000\u014e\u014c\u0001\u0000\u0000\u0000\u014f\u0153\u0005\r\u0000\u0000"+
		"\u0150\u0152\u0003,\u0016\u0000\u0151\u0150\u0001\u0000\u0000\u0000\u0152"+
		"\u0155\u0001\u0000\u0000\u0000\u0153\u0151\u0001\u0000\u0000\u0000\u0153"+
		"\u0154\u0001\u0000\u0000\u0000\u0154\u0156\u0001\u0000\u0000\u0000\u0155"+
		"\u0153\u0001\u0000\u0000\u0000\u0156\u0157\u0005\r\u0000\u0000\u01573"+
		"\u0001\u0000\u0000\u0000\u0158\u0159\u0006\u001a\uffff\uffff\u0000\u0159"+
		"\u015a\u0003<\u001e\u0000\u015a\u016d\u0001\u0000\u0000\u0000\u015b\u015d"+
		"\n\u0002\u0000\u0000\u015c\u015e\u00032\u0019\u0000\u015d\u015c\u0001"+
		"\u0000\u0000\u0000\u015d\u015e\u0001\u0000\u0000\u0000\u015e\u015f\u0001"+
		"\u0000\u0000\u0000\u015f\u0168\u00056\u0000\u0000\u0160\u0165\u0003.\u0017"+
		"\u0000\u0161\u0162\u0005\u0002\u0000\u0000\u0162\u0164\u0003.\u0017\u0000"+
		"\u0163\u0161\u0001\u0000\u0000\u0000\u0164\u0167\u0001\u0000\u0000\u0000"+
		"\u0165\u0163\u0001\u0000\u0000\u0000\u0165\u0166\u0001\u0000\u0000\u0000"+
		"\u0166\u0169\u0001\u0000\u0000\u0000\u0167\u0165\u0001\u0000\u0000\u0000"+
		"\u0168\u0160\u0001\u0000\u0000\u0000\u0168\u0169\u0001\u0000\u0000\u0000"+
		"\u0169\u016a\u0001\u0000\u0000\u0000\u016a\u016c\u00057\u0000\u0000\u016b"+
		"\u015b\u0001\u0000\u0000\u0000\u016c\u016f\u0001\u0000\u0000\u0000\u016d"+
		"\u016b\u0001\u0000\u0000\u0000\u016d\u016e\u0001\u0000\u0000\u0000\u016e"+
		"5\u0001\u0000\u0000\u0000\u016f\u016d\u0001\u0000\u0000\u0000\u0170\u0171"+
		"\u0005\u001e\u0000\u0000\u0171\u0172\u0003,\u0016\u0000\u0172\u0174\u0005"+
		"8\u0000\u0000\u0173\u0175\u00038\u001c\u0000\u0174\u0173\u0001\u0000\u0000"+
		"\u0000\u0175\u0176\u0001\u0000\u0000\u0000\u0176\u0174\u0001\u0000\u0000"+
		"\u0000\u0176\u0177\u0001\u0000\u0000\u0000\u0177\u0178\u0001\u0000\u0000"+
		"\u0000\u0178\u0179\u00059\u0000\u0000\u01797\u0001\u0000\u0000\u0000\u017a"+
		"\u017b\u0005+\u0000\u0000\u017b\u017c\u00054\u0000\u0000\u017c\u017d\u0003"+
		".\u0017\u0000\u017d9\u0001\u0000\u0000\u0000\u017e\u0183\u0005+\u0000"+
		"\u0000\u017f\u0180\u0005+\u0000\u0000\u0180\u0181\u0005*\u0000\u0000\u0181"+
		"\u0183\u0003,\u0016\u0000\u0182\u017e\u0001\u0000\u0000\u0000\u0182\u017f"+
		"\u0001\u0000\u0000\u0000\u0183;\u0001\u0000\u0000\u0000\u0184\u0185\u0006"+
		"\u001e\uffff\uffff\u0000\u0185\u0186\u0003>\u001f\u0000\u0186\u018c\u0001"+
		"\u0000\u0000\u0000\u0187\u0188\n\u0002\u0000\u0000\u0188\u0189\u0005\u0001"+
		"\u0000\u0000\u0189\u018b\u0003:\u001d\u0000\u018a\u0187\u0001\u0000\u0000"+
		"\u0000\u018b\u018e\u0001\u0000\u0000\u0000\u018c\u018a\u0001\u0000\u0000"+
		"\u0000\u018c\u018d\u0001\u0000\u0000\u0000\u018d=\u0001\u0000\u0000\u0000"+
		"\u018e\u018c\u0001\u0000\u0000\u0000\u018f\u019a\u0003@ \u0000\u0190\u019a"+
		"\u0005+\u0000\u0000\u0191\u0192\u0005+\u0000\u0000\u0192\u0193\u0005*"+
		"\u0000\u0000\u0193\u019a\u0003,\u0016\u0000\u0194\u0195\u00056\u0000\u0000"+
		"\u0195\u0196\u0003.\u0017\u0000\u0196\u0197\u00057\u0000\u0000\u0197\u019a"+
		"\u0001\u0000\u0000\u0000\u0198\u019a\u00036\u001b\u0000\u0199\u018f\u0001"+
		"\u0000\u0000\u0000\u0199\u0190\u0001\u0000\u0000\u0000\u0199\u0191\u0001"+
		"\u0000\u0000\u0000\u0199\u0194\u0001\u0000\u0000\u0000\u0199\u0198\u0001"+
		"\u0000\u0000\u0000\u019a?\u0001\u0000\u0000\u0000\u019b\u01a0\u0005,\u0000"+
		"\u0000\u019c\u01a0\u0005-\u0000\u0000\u019d\u01a0\u0005.\u0000\u0000\u019e"+
		"\u01a0\u0003B!\u0000\u019f\u019b\u0001\u0000\u0000\u0000\u019f\u019c\u0001"+
		"\u0000\u0000\u0000\u019f\u019d\u0001\u0000\u0000\u0000\u019f\u019e\u0001"+
		"\u0000\u0000\u0000\u01a0A\u0001\u0000\u0000\u0000\u01a1\u01a2\u0007\b"+
		"\u0000\u0000\u01a2C\u0001\u0000\u0000\u0000-GQX^jpu}\u0084\u008a\u0094"+
		"\u0099\u009b\u00a0\u00a6\u00b0\u00b3\u00b7\u00c4\u00d3\u00df\u00e5\u00f1"+
		"\u00f6\u00fc\u010a\u0111\u011b\u0126\u0129\u012d\u012f\u0137\u014a\u014c"+
		"\u0153\u015d\u0165\u0168\u016d\u0176\u0182\u018c\u0199\u019f";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}