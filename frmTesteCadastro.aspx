<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmTesteCadastro.aspx.vb" Inherits="frmTesteCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--<a href="App_Code/Acesso/">App_Code/Acesso/</a>
<a href="App_Code/Acesso/">App_Code/Acesso/</a>
<a href="App_Code/Acesso/">App_Code/Acesso/</a>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
    </section>

    <section class="content">
        <h4 class="page-header">Formulario Cadastro Padrão</h4>
        <div class="box-body">
            <div class="row">
                <div class="col-md-8">
                    <div class="form-group">
                        <label for="NomeAluno">Nome da Aluno:</label>
                        <asp:DropDownList runat="server" class="form-control" ID="drpAluno" Enable="true" />
                    </div>
                </div>
            <div class="col-md-8">
                <div class="form-group">
                    <label for="NomeMae">Nome da mãe:</label>
                    <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtNomeMae" name="NomeMae" placeholder="Ex: Maria das Dores Silva" MaxLength="50" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="CpfMae">CPF da mãe:</label>
                    <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtCpfMae" name="CpfMae" placeholder="Ex: 12345678912" MaxLength="11"/>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group">
                    <label for="NomePai">Nome do pai:</label>
                    <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtNomePai" name="NomePai" placeholder="Ex: João Gomes da Silva" MaxLength="50" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="CpfPai">CPF do pai:</label>
                    <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtCpfPai" name="CpfMae" placeholder="Ex: 12345678912" MaxLength="11" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="TelefoneResponsavel">Telefone do responsável:</label>
                    <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtTelefoneResponsavel" name="TelefoneResponsavel" placeholder="Ex.: 98987654321" MaxLength="20" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="RgAluno">RG do aluno:</label>
                    <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtRgAluno" name="RgAluno" placeholder="Ex.: 1234567889012" MaxLength="16" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="EmissaoRGAluno">Data de emissão do RG do Aluno:</label>
                    <asp:TextBox runat="server" required="required" type="date" class="form-control" ID="txtEmissaoRGAluno" name="EmissaoRgAluno" placeholder="Ex.: 12/12/1234" MaxLength="13" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="DataNascimentoAluno">Data de nascimento do Aluno:</label>
                    <asp:TextBox runat="server" required="required" type="date" class="form-control" ID="txtDataNascimentoAluno" name="DataNascimentoAluno" placeholder="Ex.: 12/12/1234" MaxLength="8" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="DataeHoraCadastro">Horário de cadastro</label>
                    <asp:TextBox runat="server" required="required" type="text" Class="form-control" ID="txtDataeHoraCadastro" name="DataeHoraCadastro" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="Sexo">Sexo do aluno:</label>
                    <asp:DropDownList runat="server" required="required" ID="drpSexo" class="form-control" name="Sexo">
                        <asp:ListItem Value="">Selecione</asp:ListItem>
                        <asp:ListItem Value="0">Masculino</asp:ListItem>
                        <asp:ListItem Value="1">Feminino</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12">
                <label></label>
            </div>
        </div>

        </div>
            <div class="box-footer">
                <div class="col-md-4">
                    <asp:Button class="btn btn-primary" runat="server" ID="btnSalvar" Text="Salvar" />
                </div>

                <div class="col-md-4">
                    <asp:Button class="btn btn-primary" runat="server" ID="Button1" Text="Limpar Campos" />
                </div>
            </div>

        <div class="box-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-aqua" />
                    <asp:GridView ID="grdDocumentos" runat="server" CssClass="table table-bordered" PagerStyle-CssClass="paginacao" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="CI02_ID_DOCUMENTOS, CI01_ID_ALUNO, CI01_NM_ALUNO">
                        <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CI01_ID_ALUNO" SortExpression="CI01_ID_ALUNO" HeaderText="Numero ID do aluno" />
                            <asp:BoundField DataField="CI01_NM_ALUNO" SortExpression="CI01_NM_ALUNO" HeaderText="Nome do aluno" />
                            <asp:BoundField DataField="CI02_ID_DOCUMENTOS" SortExpression="CI02_ID_DOCUMENTOS" HeaderText="ID Documento" />                           
                            <asp:BoundField DataField="CI02_NU_CPF_MAE" SortExpression="CI02_NU_CPF_MAE" HeaderText="Numero cpf MAE" />
                            <asp:TemplateField HeaderText="Editar/Excluir" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <asp:LinkButton ID="lnkEditarDocumentos" runat="server" class="btn btn-social-icon bg-blue" CommandName="EDITAR" ToolTip="EditarDocumentos">
                                            <i id="iEditarDocumentos" runat="server" class="fa fa-mortar-board"></i>
                                        <asp:LinkButton ID="lnkExcluirDocumentos" runat="server" class="btn btn-social-icon bg-red" CommandName="EXCLUIR" ToolTip="ExcluirDocumentos">
                                            <i id="iExcluirDocumentos" runat="server" class="fa fa-mortar-board"></i>
                                        </asp:LinkButton>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
