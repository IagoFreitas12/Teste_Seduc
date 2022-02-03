Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Text

Public Class Documentos
    Private CI02_ID_DOCUMENTOS As Integer
    Private CI01_ID_ALUNO As Integer
    Private CI02_NM_MAE As String
    Private CI02_NU_CPF_MAE As String
    Private CI02_NM_PAI As String
    Private CI02_NU_CPF_PAI As String
    Private CI02_NU_TELEFONE_RESPONSAVEL As String
    Private CI02_NU_RG_ALUNO As String
    Private CI02_DT_EMISSAO_RG_ALUNO As String
    Private CI02_DT_NASCIMENTO_ALUNO As String
    Private CI02_TP_SEXO_ALUNO As String
    Private CI02_DH_CADASTRO As String

    Public Property IdDocumentos() As Integer
        Get
            Return CI02_ID_DOCUMENTOS
        End Get
        Set(ByVal value As Integer)
            CI02_ID_DOCUMENTOS = value
        End Set
    End Property


    Public Property IdAluno() As Integer
        Get
            Return CI01_ID_ALUNO
        End Get
        Set(ByVal Value As Integer)
            CI01_ID_ALUNO = Value
        End Set
    End Property

    Public Property NomeMae() As String
        Get
            Return CI02_NM_MAE
        End Get
        Set(ByVal Value As String)
            CI02_NM_MAE = Value
        End Set
    End Property

    Public Property CpfMae() As String
        Get
            Return CI02_NU_CPF_MAE
        End Get
        Set(ByVal Value As String)
            CI02_NU_CPF_MAE = Value
        End Set
    End Property
    Public Property NomePai() As String
        Get
            Return CI02_NM_PAI
        End Get
        Set(ByVal Value As String)
            CI02_NM_PAI = Value
        End Set
    End Property
    Public Property CpfPai() As String
        Get
            Return CI02_NU_CPF_PAI
        End Get
        Set(ByVal Value As String)
            CI02_NU_CPF_PAI = Value
        End Set
    End Property
    Public Property TelefoneResponsavel() As String
        Get
            Return CI02_NU_TELEFONE_RESPONSAVEL
        End Get
        Set(ByVal Value As String)
            CI02_NU_TELEFONE_RESPONSAVEL = Value
        End Set
    End Property
    Public Property RgAluno() As String
        Get
            Return CI02_NU_RG_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_NU_RG_ALUNO = Value
        End Set
    End Property
    Public Property EmissaoRgAluno() As String
        Get
            Return CI02_DT_EMISSAO_RG_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_DT_EMISSAO_RG_ALUNO = Value
        End Set
    End Property
    Public Property DataNascimentoAluno() As String
        Get
            Return CI02_DT_NASCIMENTO_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_DT_NASCIMENTO_ALUNO = Value
        End Set
    End Property
    Public Property Sexo() As String
        Get
            Return CI02_TP_SEXO_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_TP_SEXO_ALUNO = Value
        End Set
    End Property
    Public Property DataeHoraCadastro() As Date
        Get
            Return CI02_DH_CADASTRO
        End Get
        Set(ByVal Value As Date)
            CI02_DH_CADASTRO = Value
        End Set
    End Property

    Public Sub New(Optional ByVal IdDocumentos As Integer = 0)
        If IdDocumentos > 0 Then
            Obter(IdDocumentos)
        End If
    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & IdDocumentos)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("CI02_ID_DOCUMENTOS") = ProBanco(CI02_ID_DOCUMENTOS, eTipoValor.CHAVE)
        dr("CI01_ID_ALUNO") = ProBanco(CI01_ID_ALUNO, eTipoValor.CHAVE)
        dr("CI02_NM_MAE") = ProBanco(CI02_NM_MAE, eTipoValor.TEXTO)
        dr("CI02_NU_CPF_MAE") = ProBanco(CI02_NU_CPF_MAE, eTipoValor.TEXTO)
        dr("CI02_NM_PAI") = ProBanco(CI02_NM_PAI, eTipoValor.TEXTO)
        dr("CI02_NU_CPF_PAI") = ProBanco(CI02_NU_CPF_PAI, eTipoValor.TEXTO)
        dr("CI02_NU_TELEFONE_RESPONSAVEL") = ProBanco(CI02_NU_TELEFONE_RESPONSAVEL, eTipoValor.TEXTO)
        dr("CI02_NU_RG_ALUNO") = ProBanco(CI02_NU_RG_ALUNO, eTipoValor.TEXTO)
        dr("CI02_DT_EMISSAO_RG_ALUNO") = ProBanco(CI02_DT_EMISSAO_RG_ALUNO, eTipoValor.TEXTO)
        dr("CI02_DT_NASCIMENTO_ALUNO") = ProBanco(CI02_DT_NASCIMENTO_ALUNO, eTipoValor.TEXTO)
        dr("CI02_TP_SEXO_ALUNO") = ProBanco(CI02_TP_SEXO_ALUNO, eTipoValor.TEXTO)
        dr("CI02_DH_CADASTRO") = ProBanco(CI02_DH_CADASTRO, eTipoValor.DATA_COMPLETA)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Sub Obter(ByVal IdDocumentos As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & IdDocumentos)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            CI02_ID_DOCUMENTOS = DoBanco(dr("CI02_ID_DOCUMENTOS"), eTipoValor.CHAVE)
            CI01_ID_ALUNO = DoBanco(dr("CI01_ID_ALUNO"), eTipoValor.CHAVE)
            CI02_NM_MAE = DoBanco(dr("CI02_NM_MAE"), eTipoValor.TEXTO)
            CI02_NU_CPF_MAE = DoBanco(dr("CI02_NU_CPF_MAE"), eTipoValor.TEXTO)
            CI02_NM_PAI = DoBanco(dr("CI02_NM_PAI"), eTipoValor.TEXTO)
            CI02_NU_CPF_PAI = DoBanco(dr("CI02_NU_CPF_PAI"), eTipoValor.TEXTO)
            CI02_NU_TELEFONE_RESPONSAVEL = DoBanco(dr("CI02_NU_TELEFONE_RESPONSAVEL"), eTipoValor.TEXTO)
            CI02_NU_RG_ALUNO = DoBanco(dr("CI02_NU_RG_ALUNO"), eTipoValor.TEXTO)
            CI02_DT_EMISSAO_RG_ALUNO = DoBanco(dr("CI02_DT_EMISSAO_RG_ALUNO"), eTipoValor.TEXTO)
            CI02_DT_NASCIMENTO_ALUNO = DoBanco(dr("CI02_DT_NASCIMENTO_ALUNO"), eTipoValor.TEXTO)
            CI02_TP_SEXO_ALUNO = DoBanco(dr("CI02_TP_SEXO_ALUNO"), eTipoValor.TEXTO)
            CI02_DH_CADASTRO = DoBanco(dr("CI02_DH_CADASTRO"), eTipoValor.TEXTO)

        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional ByVal IdDocumentos As Integer = 0,
                              Optional ByVal IdAluno As Integer = 0,
                              Optional ByVal NomeMae As String = "",
                              Optional ByVal CpfMae As String = "",
                              Optional ByVal NomePai As String = "",
                              Optional ByVal CpfPai As String = "",
                              Optional ByVal TelefoneResponsavel As String = "",
                              Optional ByVal RgAluno As String = "",
                              Optional ByVal EmissaoRgAluno As String = "",
                              Optional ByVal DataNascimentoAluno As String = "",
                              Optional ByVal Sexo As String = "",
                              Optional ByVal DataeHoraCadastro As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS is not null")

        If IdDocumentos > 0 Then
            strSQL.Append(" and CI02_ID_DOCUMENTOS = " & IdDocumentos)
        End If

        If IdAluno > 0 Then
            strSQL.Append(" and CI01_ID_ALUNO = " & IdAluno)
        End If

        If NomeMae <> "" Then
            strSQL.Append(" and upper(CI02_NM_MAE) like '%" & NomeMae.ToUpper & "%'")
        End If

        If CpfMae <> "" Then
            strSQL.Append(" and upper(CI02_NU_CPF_MAE) like '%" & CpfMae.ToUpper & "%'")
        End If

        If NomePai <> "" Then
            strSQL.Append(" and upper(CI02_NM_PAI) like '%" & NomePai & "%'")
        End If

        If CpfPai <> "" Then
            strSQL.Append(" and upper(CI02_NU_CPF_PAI) like '%" & CpfPai.ToUpper & "%'")
        End If

        If TelefoneResponsavel <> "" Then
            strSQL.Append(" and upper(CI02_NU_TELEFONE_RESPONSAVEL) like '%" & TelefoneResponsavel.ToUpper & "%'")
        End If

        If RgAluno <> "" Then
            strSQL.Append(" and upper(CI02_NU_RG_ALUNO) like '%" & RgAluno.ToUpper & "%'")
        End If

        If EmissaoRgAluno <> "" Then
            strSQL.Append(" and upper(CI02_DT_EMISSAO_RG_ALUNO) like '%" & EmissaoRgAluno.ToUpper & "%'")
        End If

        If DataNascimentoAluno <> "" Then
            strSQL.Append(" and upper(CI02_DT_NASCIMENTO_ALUNO) like '%" & DataNascimentoAluno.ToUpper & "%'")
        End If

        If Sexo <> "" Then
            strSQL.Append(" and upper(CI02_TP_SEXO_ALUNO) like '%" & Sexo.ToUpper & "%'")
        End If

        If DataeHoraCadastro <> "" Then
            strSQL.Append(" and upper(CI02_DH_CADASTRO) like '%" & DataeHoraCadastro.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "CI02_ID_DOCUMENTOS", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select *")
        strSQL.Append(" from CI02_DOCUMENTOS ORDER BY CI02_ID_DOCUMENTOS ASC")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        '
        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim DocumentosUltimo As Integer

        strSQL.Append(" select max(CI02_ID_DOCUMENTOS) from CI02_DOCUMENTOS")

        With cnn.AbrirDataTable(strSQL.ToString)
            If Not IsDBNull(.Rows(0)(0)) Then
                DocumentosUltimo = .Rows(0)(0)
            Else
                DocumentosUltimo = 0
            End If
        End With

        '
        cnn = Nothing

        Return DocumentosUltimo

    End Function

    Public Function Excluir(ByVal Documentos As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & Documentos)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        '
        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class
