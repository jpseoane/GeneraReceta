<%@ Page Title="Receta" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NuevaReceta.aspx.vb" Inherits="GenerarReceta.Nuevoreceta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
      
</asp:Content>
    
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    
     <hgroup class="title">
        <h1><%: Title %> .</h1>
         <h1>Nuevo</h1>
    </hgroup>
     <div class="divBody">
         <div class="form-row">
                
                    <div class="form-group col-lg-4  " >                
                        <label for="ddlAfiliado">Afiliado</label> 
                        <asp:DropDownList ID="ddlAfiliado" runat="server" CssClass="form-control" 
                            DataTextField="Apellido" DataValueField="ID" AutoPostBack="true" >                           
                        </asp:DropDownList>                                
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="ddlAfiliado" InitialValue="0" ForeColor="Red"                            
                        ErrorMessage="Debe seleccionar un afiliado." Display="Dynamic"
                        ToolTip="Seleccion de afiliado" 
                   >*</asp:RequiredFieldValidator>
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
                    <input runat="server" id="txtNumAfiliado" type="text" class="form-control"   required/>
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
                <div class="form-group col-lg-8" style="margin:0px;" >
                        <label for="txtObservacion">Observación</label>
                        <asp:TextBox ID="txtObservacion" runat="server"  Height="100px" TextMode="MultiLine" MaxLength="240" TabIndex="10"   ></asp:TextBox>                                 
                </div>            
          </div>
          <div class="form-row">
                <div class="form-group col-lg-4">
                    <label for="txtApellido">Medicamento</label>
                    <asp:DropDownList ID="ddlMedicamentos"  CssClass="form-control"
                        DataTextField="Descripcion" DataValueField="ID" runat="server" 
                        AutoPostBack="true"></asp:DropDownList>    
                    <asp:Button ID="btnActualizar" CausesValidation="false" runat="server"  Width="150px" 
                        Height="40px" Text="Actualizar" ToolTip="Actualizar el listado de medicamentos" class="btn btn-primary"  formnovalidate="" />                  
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                        ControlToValidate="ddlMedicamentos" InitialValue="0" ForeColor="Red"                            
                        ErrorMessage="Debe seleccionar un medicamento." Display="Dynamic"
                        ToolTip="Seleccion de medicamento" 
                   >*</asp:RequiredFieldValidator>                            
                </div>
                <div class="form-group col-lg-4">
                    <label for="txtCantidad">Cantidad</label>
                    <input runat="server" id="txtCantidad" type="number" value="1" class="form-control"  style="width:150px; margin:0px;"  required/>                    
                    <asp:Button ID="btnAgregar" runat="server"  Text="Agregar" class="btn btn-primary"    />                  
                </div>
               <div class="form-group col-lg-4">
                    
                </div>
              <div class="form-group col-lg-12">
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server"  CssClass="alert-danger"
                    HeaderText="<p>Por favor corrija los siguientes errores para confirmar</p>" 
                    DisplayMode="BulletList"  />       
                </div>
                 
           </div>
         <div class="form-group col-lg-12 ml-4" >        
                <asp:GridView ID="gvListMed" runat="server" CellPadding="4" CellSpacing="0"  
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
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" NullDisplayText="Sin Nombre" SortExpression="descripcion" >
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" NullDisplayText="Sin cantidad" SortExpression="cantidad" >
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />                            
                        </asp:BoundField>
                                                
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>                                
                                <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                    CommandName="Borrar" CommandArgument='<%#Eval("Id")%>'
                                    ImageUrl="~/Images/doc_delete.png" ToolTip="Eliminar medicamento" Height="24px" Width="24px" formnovalidate="" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Size="Smaller"  BorderStyle="None"  BorderWidth="5px"/>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>                                    
                  </Columns>
                </asp:GridView>
            </div>

     
         <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" formnovalidate=""/>
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate=""/>
           </div>
        </div>         
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeReceta" runat="server" class="alert alert-success" role="alert" visible="false">
                Receta Cargada
                </div>
            </div>
        </div>
   </div>
    
     
    
</asp:Content>
