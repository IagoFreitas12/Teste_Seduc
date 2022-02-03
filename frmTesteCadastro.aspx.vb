Enum ColunasGrid_grdDocumentos As Integer
    Selecionar
    Documentos
    buttons
End Enum
Partial Class frmTesteCadastro
    Inherits System.Web.UI.Page
    'Private txtDocumentos As Object
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
            CarregarListaAluno()
        End If
        'Validacao.Outros(txtCpfMae, False, "CpfMae",, Validacao.eFormato.CPF)
        'Validacao.Outros(txtCpfPai, False, "CpfPai",, Validacao.eFormato.CPF)
        'Validacao.Outros(txtTelefoneResponsavel, False, "TelefoneResponsavel",, Validacao.eFormato.TELEFONE)
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

#Region "Funções de Cadastro"

    Private Sub LimparCampos()

        txtNomeMae.Text = ""
        txtCpfMae.Text = ""
        txtNomePai.Text = ""
        txtCpfPai.Text = ""
        txtTelefoneResponsavel.Text = ""
        txtRgAluno.Text = ""
        txtEmissaoRGAluno.Text = ""
        txtDataNascimentoAluno.Text = ""
        txtDataeHoraCadastro.Text = ""

        drpSexo.ClearSelection()

        ' txtDocumentos.Focus()
    End Sub

    Private Sub Salvar()
        Dim objDocumentos As New Documentos(ViewState("Documentos"))
        With objDocumentos
            .NomeMae = txtNomeMae.Text
            .CpfMae = txtCpfMae.Text
            .NomePai = txtNomePai.Text
            .CpfPai = txtCpfPai.Text
            .TelefoneResponsavel = txtTelefoneResponsavel.Text
            .RgAluno = txtRgAluno.Text
            .EmissaoRgAluno = txtEmissaoRGAluno.Text
            .DataNascimentoAluno = txtDataNascimentoAluno.Text
            .DataeHoraCadastro = txtDataeHoraCadastro.Text
            .IdAluno = drpAluno.SelectedValue

            .Salvar()

        End With
        objDocumentos = Nothing
    End Sub

    Private Sub Editar()
        Dim objDocumentos As New Documentos(ViewState("Documentos"))
        With objDocumentos
            txtNomeMae.Text = .NomeMae
            txtCpfMae.Text = .CpfMae
            txtNomePai.Text = .NomePai
            txtCpfPai.Text = .CpfPai
            txtTelefoneResponsavel.Text = .TelefoneResponsavel
            txtRgAluno.Text = .RgAluno
            txtEmissaoRGAluno.Text = .EmissaoRgAluno
            txtDataNascimentoAluno.Text = .DataNascimentoAluno
            txtDataeHoraCadastro.Text = .DataeHoraCadastro
            drpAluno.SelectedValue = .IdAluno



        End With
        objDocumentos = Nothing
    End Sub

    Private Sub Excluir(ByVal IdDocumentos As Integer)
        Dim objDocumentos As New Documentos

        If objDocumentos.Excluir(IdDocumentos) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objDocumentos = Nothing

        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub Voltar()
        Response.Redirect(Request.Url.ToString)

        LimparCampos()
    End Sub


#End Region

#Region "Eventos de Cadastro"

    Protected Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

#End Region

#Region "Funções de Listagem"

    Private Sub CarregarListaAluno()

        Dim objAluno As New Aluno

        With drpAluno
            .DataSource = objAluno.ObterTabela()
            .DataValueField = "CODIGO"
            .DataTextField = "DESCRICAO"
            .DataBind()
            .Items.Insert(0, "...")
            .SelectedIndex = 0

        End With
        objAluno = Nothing
    End Sub



    Private Sub CarregarGrid()
        Dim objDocumentos As New Documentos

        grdDocumentos.DataSource = objDocumentos.Pesquisar(ViewState("OrderBy"))
        grdDocumentos.DataBind()

        objDocumentos = Nothing

        lblRegistros.Text = DirectCast(grdDocumentos.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub
#End Region

#Region "Eventos de Listagem"
    Protected Sub grdDocumentos_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDocumentos.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdDocumentos.DataKeys(e.CommandArgument).Item(0))
        End If


    End Sub


    Private Sub grdDocumentos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDocumentos.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header

            Case DataControlRowType.DataRow

                Dim lnkExcluirDocumentos As New LinkButton
                lnkExcluirDocumentos = DirectCast(e.Row.Cells(ColunasGrid_grdDocumentos.buttons).FindControl("lnkExcluirDocumentos"), LinkButton)
                lnkExcluirDocumentos.CommandArgument = e.Row.RowIndex
                lnkExcluirDocumentos = Nothing

        End Select
    End Sub



#End Region
End Class
