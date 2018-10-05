<%@ Page Title="Recetas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Adminreceta.aspx.vb" Inherits="GenerarReceta.Adminreceta" %>
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
                    <a href="http://localhost/GenerarReceta/Views/NuevaReceta.aspx" target="_blank" style="background-color:transparent">
                        <img src="../../Images/newreceta.png" title="Adherir receta" width="32" height="32" /></a>         
                </div>
            </div>
       <div class="form-row" id="divAfiliado" runat="server" visible="false">
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlAfiliado">Afiliado</label> 
                        <asp:DropDownList ID="ddlAfiliado" runat="server" CssClass="form-control"
                            DataTextField="Apellido" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
                 </div>           
            </div>
       <div class="form-row">                 
                    <div class="form-group col-lg-3 " >                
                        <label for="txtNombre">Nombre</label> 
                        <input runat="server" id="txtNombre" type="text"  class="form-control"    readonly/>
                    </div>             
                <div class="form-group col-lg-3">
                    <label for="txtApellido">Apellido</label>
                    <input runat="server" id="txtApellido" type="text" class="form-control" readonly />
                </div>
                 <div class="form-group col-lg-6" >                
                    <label for="txtOficina">Oficina</label>
                    <input runat="server" id="txtOficina" type="text" class="form-control" readonly/>
                </div>
                <div class="form-group col-lg-6" >
                    <label for="txtNumAfi">Numero de afiliado</label>
                    <input runat="server" id="txtNumAfi" type="text" class="form-control" readonly/>
                </div>
            </div>
       <div class="form-row">
           <div class="form-group col-lg-3">
                <label for="ddlTipoReceta">Tipo de receta</label>
                <asp:DropDownList ID="ddlTipoReceta" runat="server" CssClass="form-control"
                    DataTextField="Tipo" DataValueField="ID" AutoPostBack="true" >                           
                    <asp:ListItem Text="Medicamento" Value="M" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Practica" Value="P" ></asp:ListItem>
                     </asp:DropDownList>                  
             </div>
            <div class="form-group col-lg-3">
                    <label for="txtFechaReceta">Fecha de Receta</label>                
                   <input  runat="server" type="date" id="txtFechaReceta" name="fechanac"   style="width:200px; margin:0px !important; border-radius:0.25rem;" />                
            </div>
            <div class="form-group col-lg-3">
                    <label for="txtFechaAntReceta">Fecha de Ultima Receta</label>                
                   <input  runat="server" type="date" id="txtFechaAntReceta" name="fechanac"   style="width:200px; margin:0px !important; border-radius:0.25rem; " readonly/>                
            </div>
         </div>
       <div class="form-row">
            <div class="form-group col-lg-2" >
                    <label for="txtCantTotal">Cantidad Total</label>
                    <input id="txtCantTotal"  runat="server" type="text" class="form-control" placeholder="Edad"   readonly/>
             </div> 

            <div class="form-group col-lg-8" style="margin:0px;" >
                    <label for="txtObservacion">Observación</label>
                    <asp:TextBox ID="txtObservacion" runat="server"  Height="100px" TextMode="MultiLine" MaxLength="240" TabIndex="10" ></asp:TextBox>                                 
            </div>
        </div>
       <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" />
               <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn  btn-secondary" visible="False"/>
           </div>
        </div>         
       <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeReceta" runat="server" class="alert alert-success" role="alert" visible="false">
                Receta Cargada
                </div>
            </div>
        </div>
       <div class="form-row">
            <div class="form-group col-lg-12" >        
                <asp:GridView ID="gvReceta" runat="server" CellPadding="4" CellSpacing="0" HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" AllowSorting="True" PageSize="20" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" >
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
                        <asp:BoundField DataField="afiliado" HeaderText="Afiliado" NullDisplayText="Sin afiliado" SortExpression="afiliado" >
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tipo" HeaderText="Tipo" NullDisplayText="Sin tipo" SortExpression="tipo" >
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />                            
                        </asp:BoundField>                                                
                        <asp:BoundField DataField="cantidadTotal" HeaderText="Cantidad Total" NullDisplayText="NO" SortExpression="cantidadTotal" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>                                                                                                            
                        <asp:BoundField DataField="fechaactual" HeaderText="Fecha Actual" NullDisplayText="fechaactual" SortExpression="fechaactual" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False"  />
                            <HeaderStyle  HorizontalAlign="Center" />
                        </asp:BoundField>                                                                                    
                        <asp:BoundField DataField="fechaanterior" HeaderText="Fec. Ult. Receta" NullDisplayText="fechaanterior" SortExpression="fechaanterior" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            <HeaderStyle  HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="observacion" HeaderText="Observacion" NullDisplayText="Observacion" SortExpression="observacion" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                        </asp:BoundField>                                                                                                                                                                        
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" causesvalidation="false"  ImageUrl="~/Images/editreceta.png"
                                    commandname="Editar" commandargument='<%# Eval("Id")%>' Height="24px" Width="24px" 
                                    ToolTip="Editar receta" />
                                <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                    CommandName="Borrar" CommandArgument='<%#Eval("Id")%>'
                                    ImageUrl="~/Images/delreceta.png" ToolTip="Eliminar receta" Height="24px" Width="24px"  />
                                
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
                                       ¿Queres eliminar esta receta?
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
