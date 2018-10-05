<%@ Page Title="Afiliado" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Nuevoafiliado.aspx.vb" Inherits="GenerarReceta.Nuevoafiliado" %>
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
            <div class="form-group col-lg-2  text-hide">
                <label for="txtEdad" >Edad</label>
                <input id="txtEdad"  runat="server" type="text" class="form-control  text-hide" placeholder="Edad"  />
            </div> 
        </div>
        <div class="form-row" >
                <div class="form-group col-lg-6" >                
                    <label for="txtOficina">Oficina</label>
                    <input runat="server" id="txtOficina" type="text" class="form-control" />
                </div>
                <div class="form-group col-lg-6" >                    
                    <label for="txtNumAfi" >Numero de afiliado</label>
                    <input runat="server" id="txtNumAfi" type="text" class="form-control" required/>
                </div>
        </div>
        <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate=""/>
           </div>
        </div>         
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeAfiliado" runat="server" class="alert alert-success" role="alert" visible="false">
                Afiliado Cargado
                </div>
            </div>
        </div>
 </div>
     

</asp:Content>
