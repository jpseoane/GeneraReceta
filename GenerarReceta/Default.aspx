<%@ Page Title="Inicio" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="GenerarReceta._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Sistema para el control y gestion de recetas</h2>
            </hgroup>
            <p>
                <mark>Registre, actualice y elimine</mark> afiliado, recetas y medicamentos por medio de la gestion Administracion, tambien puede consultar
                las recetas generadas por medio de la consulta de <a href="http://localhost/GenerarReceta/Views/Consultas/RecetaAfiliado.aspx" title="Recetas por afiliado">Recetas afiliados</a> y repetir 
                las historicas si lo desea. 
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Sugerencia de uso:</h3>
    <ol class="round">
        <li class="one">
            <h5>Para comenzar</h5>
            Cargue los afiliados con la opcion del menu <a href="http://localhost/GenerarReceta/Views/Nuevoafiliado.aspx">Generar Afiliado</a>
            ingrese todos los datos y acepte para confirmar la carga
        </li>
        <li class="two">
            <h5>Seguidamente</h5>
            Ingrese los medicamentos en la opcion de menu <a href="http://localhost/GenerarReceta/Views/NuevoMedicamento.aspx">Generar medicamento</a>
            ingrese todos los datos y acepte para confirmar la carga
        </li>
        <li class="three">
            <h5>Por ultimo</h5>
            En la opcion del menu <a href="http://localhost/GenerarReceta/Views/NuevaReceta.aspx">Generar receta</a>
            seleccione el afiliado y los medicamentos de la receta para poder generarla.
        </li>  
    </ol>
</asp:Content>
