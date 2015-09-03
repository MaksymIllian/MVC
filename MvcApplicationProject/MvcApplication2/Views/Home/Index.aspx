<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication2.Models.Emploee>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Emploees</h2>
<p>
<%: Html.ActionLink("Create New", "Create") %>
</p>
   
<table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.Name) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Position) %>
        </th>
        <th>
            <%: Html.ActionLink("Active","Index", new { filter = "Active" })%> /
            <%: Html.ActionLink("Non-active","Index", new { filter = "Non-active" })%> |
            <%: Html.ActionLink("All", "index") %>
            <p>
            <%: Html.DisplayNameFor(model => model.Status) %>
             </p>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Salary) %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Name) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Position) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Status) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Salary) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
               
        </td>
    </tr>
   
<% } %>

</table>
     <p>
        <%: Html.PagingNavigator(((int)ViewData["PageNum"]), 
            (int)ViewData["CountOfItems"], 
            (int)ViewData["PageSize"]) %>
    </p>

</asp:Content>
