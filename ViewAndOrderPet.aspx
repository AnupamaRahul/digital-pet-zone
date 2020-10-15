<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.master" AutoEventWireup="true" CodeFile="ViewAndOrderPet.aspx.cs" Inherits="ViewAndOrderPet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1"><tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
         <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
         <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
         <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
         <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
        <tr>
            <td>
                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="DataGrid1_SelectedIndexChanged" Width="714px">
                    <AlternatingItemStyle BackColor="White" />
                    <Columns>
                        <asp:BoundColumn DataField="petid" HeaderText="petID" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="breed" HeaderText="Breed"></asp:BoundColumn>
                        <asp:BoundColumn DataField="price" HeaderText="Price"></asp:BoundColumn>
                        <asp:BoundColumn DataField="categories" HeaderText="Categories"></asp:BoundColumn>
                        <asp:BoundColumn DataField="gender" HeaderText="Gender"></asp:BoundColumn>
                        <asp:BoundColumn DataField="age" HeaderText="Age"></asp:BoundColumn>
                        <asp:ButtonColumn CommandName="Select" HeaderText="Order  Now" Text="Order Now"></asp:ButtonColumn>
                        <asp:TemplateColumn HeaderText="View Image">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="delete">View Image</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="image" HeaderText="Image" Visible="False"></asp:BoundColumn>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:DataGrid>
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="267px" Width="552px" Visible="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="3">
                <asp:Panel ID="Panel1" runat="server" Height="181px" Width="535px" Visible="False">
                    <table class="auto-style1" style="height: 161px; width: 97%">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcust" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label2" runat="server" Text="Shipping Address"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtship" runat="server" TextMode="MultiLine" Width="179px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Contact Number"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnum" runat="server" TextMode="Number" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="Confirm Order" OnClick="Button1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

