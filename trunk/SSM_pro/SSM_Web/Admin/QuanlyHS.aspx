<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="QuanlyHS.aspx.cs" Inherits="Admin_Default2" Title="Untitled Page" %>

<%@ Register Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table  align="center" width="700px" style="text-align: center; border: 0px none #ffffff;">
        <tr>
            <td style="text-align: center; border: 0px none #ffffff;">
                <asp:DropDownList ID="ddltim" runat="server" Height="25px">
                    <asp:ListItem Value="MaHS">Tìm theo mã học sinh</asp:ListItem>
                    <asp:ListItem Value="HoTen">Tìm theo tên học sinh</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <asp:TextBox ID="txttim" runat="server" Height="25px" Width="148px"></asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="btntim" runat="server" ImageUrl="~/Images/Search.png" OnClick="btntim_Click" />
            </td>
        </tr>
    </table>
    <p style="text-align: center">
        <asp:Button ID="btnAddNew" runat="server" OnClick="btnAddNew_Click" Text="Thêm mới học sinh"
            Width="178px" CausesValidation="False" />
    </p>
    <div class="table" align="center">
        <asp:GridView ID="gvdshs" runat="server" CellPadding="4" DataKeyNames="Mã HS" Width="700px"
            AllowPaging="True" OnSelectedIndexChanged="gvdshs_SelectedIndexChanged" CssClass="style13"
            OnPageIndexChanging="gvdshs_PageIndexChanging" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:CommandField SelectText="Chi tiết" ShowSelectButton="True" DeleteText="Xóa"
                    EditText="Sửa">
                    <ItemStyle Width="50px" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <EditRowStyle HorizontalAlign="Center" BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <div align="center">
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View2" runat="server">
                <asp:Label ID="Label9" runat="server" Width="700px" >
                    <div class="title"><h6>Thông Tin Học sinh</h6></div>
                </asp:Label>
                <asp:DetailsView ID="dths" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                    Height="50px"  Width="700px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                    <RowStyle BackColor="#EFF3FB" />
                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <Fields>
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp;&nbsp;<asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click">Sửa</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" OnClientClick="return confirm(&quot;Are you sure Delete?&quot;);">Xóa</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:DetailsView>
            </asp:View>
        </asp:MultiView>
    </div>
    <div class="table" align="center">
        <asp:MultiView ID="MultiView3" runat="server">
        <asp:View ID="View3" runat="server">
            <div class="title" style="width:700px;" align="left">
                    <h6>Sửa thông tin học sinh</h6>
            </div>
            <table align="center" style="width:700px;">
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        Mã HS
                    </td>
                    <td>
                        <asp:Label ID="lblmahs" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        Họ tên
                    </td>
                    <td>
                        <asp:TextBox ID="txthoten" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        <asp:Label ID="Label8" runat="server" Text="Giới tính"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckbgioitinh" runat="server" Text="Nam" />
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        Địa chỉ
                    </td>
                    <td>
                        <asp:TextBox ID="txtdiachi" runat="server" Width="200px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        <asp:Label ID="Label2" runat="server" Text="Số điện thoại"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsodienthoai" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        <asp:Label ID="Label3" runat="server" Text="Họ tên cha"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txthotencha" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        <asp:Label ID="Label4" runat="server" Text="Nghề nghiệp cha"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtnghenghiepcha" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        <asp:Label ID="Label5" runat="server" Text="Họ tên mẹ"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txthotenme" runat="server" Width="199px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        <asp:Label ID="Label6" runat="server" Text="Nghề nghiệp mẹ"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtnghenghiepme" runat="server" Width="197px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="background:#DEE8F5;">
                        <asp:Label ID="Label7" runat="server" Text="Ngày sinh"></asp:Label>
                    </td>
                    <td align="center" >
                        <dxe:ASPxDateEdit ID="txtDate" runat="server" Width="180px">
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cập nhật"
                            Width="114px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="False" OnClick="btnCancel_Click"
                            Text="Hủy" Width="129px" />
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:View>
        <br />
    </asp:MultiView>
    </div>
</asp:Content>
