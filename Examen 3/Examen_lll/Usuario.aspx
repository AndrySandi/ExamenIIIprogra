﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Examen_lll.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/EstiloGrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
&nbsp;&nbsp;&nbsp; &nbsp;Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp; Clave:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp; Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp; Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp; Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    &nbsp;&nbsp;
    <asp:Button ID="btnAgregar" runat="server" Height="44px" Text="AGREGAR" Width="138px" OnClick="btnAgregar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnBorrar" runat="server" Height="44px" Text="BORRAR" Width="138px" OnClick="btnBorrar_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnActualizar" runat="server" Height="44px" Text="ACTUALIZAR" Width="138px" OnClick="btnActualizar_Click" />
    <p>
          <asp:GridView ID="datagrid1" runat="server" AllowPaging="false" AutoGenerateDeleteButton="false" AutoGenerateEditButton="false" AutoGenerateSelectButton="false" CssClass="auto-style10" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" Height="197px" Width="1064px">
            </asp:GridView><p>&nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
