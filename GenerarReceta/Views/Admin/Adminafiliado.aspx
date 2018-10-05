<%@ Page Title="Afiliado" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Adminafiliado.aspx.vb" Inherits="GenerarReceta.Adminafiliado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
      .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.4;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        width: 400px;
    }
    .modalPopup .header
    {
        background-color: #5D7B9D;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
        font-size: large;
        padding-top: 15px;
    }
    .modalPopup .footer
    {
        padding: 3px;
    }
    .modalPopup .yes, .modalPopup .no
    {
        height:32px;
        color: White;
        line-height: 32px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
    }
    .modalPopup .yes
    {
        background-color: #5D7B9D;
        border: 1px solid #0DA9D0;
        width: 100px;

    }
    .modalPopup .no
    {
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
      width: 100px;

    }
    </style>        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
   
</asp:Content>
    
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">        
    
         <div class="divBody">
            <hgroup class="title">
        <h1><%: Title %> .</h1>
        <h2>Administracion</h2>
    </hgroup>
            <div class="form-row" style="text-align:right">
                <div class="form-group col-lg-12" >   
                    <a href="http://localhost/GenerarReceta/Views/Nuevoafiliado.aspx" target="_blank" style="background-color:transparent">
                        <img src="../../Images/addmale_user.png" title="Nuevo afiliado" width="32" height="32" /></a>         
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-3 " >                
                    <label for="txtNombre">Nombre</label> 
                    <input runat="server" id="txtNombre" type="text"  class="form-control"   required/>
                </div>             
            <div class="form-group col-lg-3">
                <label for="txtApellido">Apellido</label>
                <input runat="server" id="txtApellido" type="text" class="form-control"  required/>
            </div>
            <div class="form-group col-lg-3">
                <label for="txtFechaNac">Fecha de Nacimiento</label>                
                <input  runat="server" type="date" id="txtFechaNac" name="fechanac"   style="width:200px; margin:0px !important; border-radius:0.25rem;"/>                
            </div>
        </div>
        <div class="form-row">
                <div class="form-group col-lg-6" >                
                    <label for="txtOficina">Oficina</label>
                    <input runat="server" id="txtOficina" type="text" class="form-control" >
                </div>
                <div class="form-group col-lg-6" >
                    <label for="txtNumAfi">Numero de afiliado</label>
                    <input runat="server" id="txtNumAfi" type="text" class="form-control" required/>
                </div>
        </div>
        <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate=""/>
               <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn  btn-secondary" visible="False"/>
           </div>
        </div>         
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeAfiliado" runat="server" class="alert alert-success" role="alert" visible="false">
                Afiliado Cargado
                </div>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <asp:GridView ID="gvAfiliados" runat="server" CellPadding="4" CellSpacing="0" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" 
                    AllowPaging="True" AllowSorting="True" PageSize="20" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" NullDisplayText="Sin Nombre" SortExpression="Nombre" >
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" NullDisplayText="Sin apellido" SortExpression="apellido" >
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"/>
                        </asp:BoundField>                        
                        <asp:BoundField DataField="oficina" HeaderText="Oficina" NullDisplayText="NO" SortExpression="oficina" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="NumeroAfiliado" HeaderText="Num. Afiliado" NullDisplayText="NO" SortExpression="NumeroAfiliado" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="FechaAlta" HeaderText="Fec.Alta" NullDisplayText="NO" SortExpression="FechaAlta" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="fechaNacimiento" HeaderText="Fec.Nac" NullDisplayText="NO" SortExpression="fechaNacimiento" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>               
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" causesvalidation="false"  ImageUrl="~/Images/edit_male_user.png"
                                    commandname="Editar" commandargument='<%# Eval("Id")%>' Height="24px" Width="24px" 
                                    ToolTip="Editar afiliado" formnovalidate="" />
                                <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    formnovalidate="" 
                                    CommandName="Borrar" CommandArgument='<%#Eval("Id")%>'
                                    ImageUrl="~/Images/deleteusers.png" ToolTip="Eliminar afiliado" Height="24px" Width="24px"  />
                                
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" DisplayModalPopupID="mpe" TargetControlID="imgbtnBorrar">
                                </ajaxToolkit:ConfirmButtonExtender>
                                <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="imgbtnBorrar" OkControlID = "btnYes"
                                    CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                                    <div class="header">
                                        Confirmación
                                    </div>
                                    <div class="body">
                                       ¿Queres eliminar este registro?
                                    </div>
                                    <div class="footer" align="right">
                                        <asp:Button ID="btnYes" runat="server" Text="Yes" Width="100px" CausesValidation="false"  />
                                        <asp:Button ID="btnNo" runat="server" Text="No" Width="100px" CausesValidation="false" />
                                    </div>
                                </asp:Panel>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Size="Smaller"  BorderStyle="None"  BorderWidth="5px"/>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>                                    
                  </Columns>
                </asp:GridView>
            </div>
        </div>
   </div> 
   
</asp:Content>
