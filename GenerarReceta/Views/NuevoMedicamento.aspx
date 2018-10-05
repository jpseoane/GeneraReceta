<%@ Page Title="Medicamento" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NuevoMedicamento.aspx.vb" Inherits="GenerarReceta.Nuevomedicamento" %>
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
                <label for="txtDescripcion">Descripción</label> 
                <input runat="server" id="txtDescripcion" type="text"  class="form-control"  placeholder="Descripción"   required/>
            </div>             
            <div class="form-group col-lg-3">
                <label for="txtFormato">Dosis</label><input runat="server" id="txtDosis" type="text" class="form-control"  placeholder="Dosis"   required/>
            </div>            
            
            <div class="form-group col-lg-2" >
                <label for="txtCantidad">Cantidad por caja</label>
                <input id="txtCantidadxCaja"  runat="server" type="text" class="form-control" placeholder="Cantidad"  required/>
            </div> 
        </div>
        <div class="form-row">
                <div class="form-group col-lg-6" >                
                    <label for="txtDroga">Droga</label>
                    <input runat="server" id="txtDroga" type="text" class="form-control"  placeholder="Droga"  />
                </div>
                <div class="form-group col-lg-6" >
                    <label for="txtLaboratorio">Laboratorio</label>
                    <input runat="server" id="txtLaboratorio" type="text" class="form-control"  placeholder="Laboratorio"  />
                </div>
        </div>
        <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" />
           </div>
        </div>         
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeMedicamento" runat="server" class="alert alert-success" role="alert" visible="false">
                    Medicamento Cargado </div>
            </div>
        </div>
     </div>
    
     

</asp:Content>
