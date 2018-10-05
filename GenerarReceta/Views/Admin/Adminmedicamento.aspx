<%@ Page Title="Medicamentos" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Adminmedicamento.aspx.vb" Inherits="GenerarReceta.Adminmedicamento" %>
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
     <hgroup class="title">
        <h1><%: Title %> .</h1>
        <h2>Administracion</h2>
    </hgroup>
    <div class="divBody">
            <div class="form-row" style="text-align:right">
                <div class="form-group col-lg-12" >   
                    <a href="http://localhost/GenerarReceta/Views/Nuevomedicamento.aspx" target="_blank" style="background-color:transparent">
                        <img src="../../Images/doc_add.png" title="Adherir medicamento" width="32" height="32" /></a>         
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-3 " >                
                    <label for="txtDescripcion">Descripcion</label> 
                    <input runat="server" id="txtDescripcion" type="text"  class="form-control"  placeholder="Descripcion"   required/>
                </div>             
            <div class="form-group col-lg-3">
                <label for="txtFormato">Dosis</label>
                <input runat="server" id="txtDosis" type="text" class="form-control" placeholder="Dosis"    required/>
            </div>
            <div class="form-group col-lg-2" >
                <label for="txtCantporcaja">Cantidad por Caja</label>
                <input id="txtCantporcaja"  runat="server" type="text" class="form-control" placeholder="Cantidad por caja"   >
            </div> 
        </div>
        <div class="form-row">
                <div class="form-group col-lg-6" >                
                    <label for="txtDroga">Droga</label>
                    <input runat="server" id="txtDroga" type="text" class="form-control" placeholder="Droga"  >
                </div>
                <div class="form-group col-lg-6" >
                    <label for="txtLaboratorio">Laboratorio</label>
                    <input runat="server" id="txtLaboratorio" type="text" class="form-control" placeholder="Laboratorio"  />
                </div>
        </div>
        <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" CausesValidation="false" formnovalidate="" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate=""/>
               <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn  btn-secondary" visible="False"/>
           </div>
        </div>         
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeMedicamento" runat="server" class="alert alert-success" role="alert" visible="false">
                Medicamento Cargado
                </div>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <asp:GridView ID="gvMedicamento" runat="server" CellPadding="4" CellSpacing="0" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%"
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
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" NullDisplayText="Sin Nombre" SortExpression="descripcion" >
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dosis" HeaderText="Formato" NullDisplayText="Sin dosis" SortExpression="dosis" >
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />                            
                        </asp:BoundField>
                        <asp:BoundField DataField="cantporcaja" HeaderText="Cant. x Caja" NullDisplayText="Sin cantidad"  SortExpression="cantporcaja" >
                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True"  />
                            <HeaderStyle  HorizontalAlign="Center" Wrap="false" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="fechaentrada" HeaderText="Fec. Entrada" NullDisplayText="NO" SortExpression="fechaentrada" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            <HeaderStyle  HorizontalAlign="Center" Wrap="false"  />
                        </asp:BoundField>                                                
                        <asp:BoundField DataField="droga" HeaderText="Droga" NullDisplayText="NO" SortExpression="droga" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>               
                        <asp:BoundField DataField="laboratorio" HeaderText="Laboratorio" NullDisplayText="NO" SortExpression="laboratorio" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>               
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" causesvalidation="false"  ImageUrl="~/Images/doc_edit.png"
                                    commandname="Editar" commandargument='<%# Eval("Id")%>' Height="24px" Width="24px" 
                                    ToolTip="Editar medicamento" formnovalidate="" />
                                <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                    CommandName="Borrar" CommandArgument='<%#Eval("Id")%>' formnovalidate=""
                                    ImageUrl="~/Images/doc_delete.png" ToolTip="Eliminar medicamento" Height="24px" Width="24px"  />
                                
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
                                        <asp:Button ID="btnYes" runat="server" Text="Yes" Width="100px" />
                                        <asp:Button ID="btnNo" runat="server" Text="No" Width="100px" />
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
