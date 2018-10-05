<%@ Page Title="Busqueda de recetas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RecetaAfiliado.aspx.vb" Inherits="GenerarReceta.RecetaAfiliado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
       <script type="text/javascript" >

         function collapseExpand(objDIV, objI) {
             var gvObject = document.getElementById(objDIV);
             var imageID = document.getElementById(objI);
             if (gvObject.style.display == "none") {
                 gvObject.style.display = "inline";
                 imageID.src = "../../Images/reducir.png";
             }

             else {
                 gvObject.style.display = "none";
                 imageID.src = "../../Images/expandir.png";
             }

         }
         
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
      
</asp:Content>
    
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    
     <hgroup class="title">
        <h1><%: Title %> .</h1>
         <h1>Consultas</h1>
    </hgroup>
     <div class="divBody">
         <div class="form-row">
                
                    <div class="form-group col-lg-4 " >                
                        <label for="ddlAfiliados">Afiliado</label> 
                        <asp:DropDownList ID="ddlAfiliados" runat="server" CssClass="form-control"
                            DataTextField="Apellido" DataValueField="ID" AutoPostBack="true" >
                        </asp:DropDownList>                                
                    </div>             
                    <div class="form-group col-lg-4 " >                
                        <label for="txtNombre">Nombre</label> 
                        <input runat="server" id="txtNombre" type="text" class="form-control"  />
                    </div>             
                     <div class="form-group col-lg-4 " >                
                        <label for="txtApellido">Apellido</label> 
                        <input runat="server" id="txtApellido" type="text" class="form-control"   />
                    </div>  
            
          </div>  
         <div class="form-row">           
           
                <div class="form-group col-lg-6 " >                
                    <label for="txtNumAfiliado">N° Afiliado</label> 
                    <input runat="server" id="txtNumAfiliado" type="text" class="form-control"   />
                </div>             
                <div class="form-group col-lg-6 " >                
                    <label for="txtOficina">Oficina</label> 
                    <input runat="server" id="txtOficina" type="text" class="form-control"  />
                </div>             
        
         </div>
         
         <div class="form-row">                  
                <div class="form-group col-lg-4">
                    <label for="ddlTipoReceta">Tipo de receta</label>
                     <asp:DropDownList ID="ddlTipoReceta" runat="server" CssClass="form-control"
                            DataTextField="Tipo" DataValueField="ID" AutoPostBack="true" >                           
                         <asp:ListItem Text="Medicamento" Value="M" Selected="True"></asp:ListItem>
                         <asp:ListItem Text="Practica" Value="P" ></asp:ListItem>
                        </asp:DropDownList>                  
                </div>
          </div>
          <div class="form-row">
               <div class="form-group col-lg-12">
                    <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" />                  
                   <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" />
                </div>
              
           </div>
          <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeRecetaAfiliado" runat="server" class="alert alert-success" role="alert" visible="false">
                    MensajeRecetaAfiliado
                </div>
            </div>
        </div>
        <div class="form-group col-lg-12" >        
           <asp:GridView ID="gvRecetas" runat="server" CellPadding="4" CellSpacing="0"  DataKeyNames="id" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="90%" >
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
                        <asp:TemplateField>
                                <ItemTemplate>
                                <div id="divExp" runat="server" visible="false">
                                    <a href="javascript:collapseExpand('Div-<%# Eval("id")%>','a-<%# Eval("id")%>');" style="background-color: transparent !important" >
                                        <img id="a-<%# Eval("id")%>"  
                                          alt="Click para ver detalle" border="0" src="../../Images/expandir.png" />
                                    </a>
                                </div>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="N°" NullDisplayText="Sin n° receta" SortExpression="id" >
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>
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
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>                                                                                    
                        <asp:BoundField DataField="fechaanterior" HeaderText="Fec. Ult. Receta" NullDisplayText="fechaanterior" SortExpression="fechaanterior" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>  
                        <asp:TemplateField HeaderText="Acciones"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" causesvalidation="false"  ImageUrl="../../Images/newreceta.png" 
                                        commandname="Repetir" commandargument='<%# Eval("id")%>' Height="24px" Width="24px" 
                                        ToolTip="Repetir receta" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>                      
                        <asp:TemplateField>
                         <ItemTemplate>
                                <tr>                                                                                                               
                                <td>
                                <td colspan="10">
                                    <div id="Div-<%# Eval("id")%>" 
                                        style="display:none;
                                        position:relative;">
                                        <asp:GridView ID="gvDetalleReceta" runat="server" AutoGenerateColumns="False"  GridLines="None"                                               
                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial"
                                                CellPadding="0" ForeColor="Black"  ShowHeader="false">
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"  />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"  />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"  />
                                                <AlternatingRowStyle BackColor="#CCCCCC" />                                        
                                                <Columns>                                                                                                                                        
                                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" ItemStyle-Width="50px" >
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False"   />
                                                    </asp:BoundField>                                                   
                                                                            
                                                    <asp:BoundField DataField="dosis" HeaderText="Dosis" ItemStyle-Width="50px" >
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False"   />
                                                    </asp:BoundField>                                                                                                                                         
                                                                                                                                    
                                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-Width="50px" >
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False"  />
                                                    </asp:BoundField>
                                                                                                                                    
                                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" ItemStyle-Width="50px" >
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False"/>
                                                    </asp:BoundField>                                                    
                                                </Columns>
                                            </asp:GridView>
                                    </div>
                                </td></tr>
                        </ItemTemplate>
                     </asp:TemplateField>                         
                  </Columns>
                </asp:GridView>
        </div>
        
   </div>
    
     
    
</asp:Content>
