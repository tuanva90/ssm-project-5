<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="QuanlyGV.aspx.cs" Inherits="Admin_QuanlyGV" Title="Untitled Page" %>

<%@ Register Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" class="style9">
        <tr>
            <td style="text-align: center">
                <asp:DropDownList ID="ddltim" runat="server" Height="25px">
                    <asp:ListItem Value="MaGV">Tìm theo mã giáo viên</asp:ListItem>
                    <asp:ListItem Value="HoTen">Tìm theo tên giáo viên</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <asp:TextBox ID="txttim" runat="server" Height="25px" Width="148px"></asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="btntim" runat="server" ImageUrl="~/Images/Search.png" OnClick="btntim_Click" />
            </td>
        </tr>
    </table>
    <p style="text-align: center">
        <asp:Button ID="btnAddNew" runat="server" OnClick="btnAddNew_Click" Text="Thêm mới giáo viên"
            Width="178px" CausesValidation="False" />
    </p>
    <div class="table" align="center">
        <asp:GridView ID="gvdsgv" runat="server" CellPadding="4" DataKeyNames="Mã GV" Width="700px"
            AllowPaging="True" OnSelectedIndexChanged="gvdshs_SelectedIndexChanged" CssClass="style13"
            OnPageIndexChanging="gvdshs_PageIndexChanging" ForeColor="#333333" GridLines="None"
            OnRowEditing="gvdsgv_RowEditing">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:CommandField SelectText="Chi tiết" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" ForeColor="Black" Font-Bold="True" />
            <PagerStyle BackColor="#666666" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <EditRowStyle HorizontalAlign="Center" BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="Black" />
        </asp:GridView>
    </div>
    <div align="center">
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View2" runat="server">
                <asp:Label ID="Label9" runat="server" Width="700px">
                    <div class="title"><h6>Thông Tin Giáo Viên</h6></div>
                </asp:Label>
                <asp:DetailsView ID="dtgv" runat="server" Width="700px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                    <RowStyle BackColor="#EFF3FB" />
                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <Fields>
                        <asp:TemplateField HeaderText="Tùy chọn">
                            <ItemTemplate>
                                &nbsp;&nbsp;<asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click">Sửa</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" OnClientClick="return confirm(&quot;Are you sure Delete?&quot;);"
                                    CommandName="Delete">Xóa</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="lblcancel" runat="server" OnClick="lblcancel_Click">Hủy</asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                &nbsp;&nbsp;
                            </EditItemTemplate>
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
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblthongtinhocsinh" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mã GV:
                        </td>
                        <td>
                            <asp:Label ID="lblmagv" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Họ tên:
                        </td>
                        <td>
                            <asp:TextBox ID="txthoten" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            <asp:Label ID="Label8" runat="server" Text="Giới tính : "></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="ckbgioitinh" runat="server" Text="Nam" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Địa chỉ
                        </td>
                        <td>
                            <asp:TextBox ID="txtdiachi" runat="server" Width="200px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Số điện thoại :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsodienthoai" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            <asp:Label ID="Label3" runat="server" Text="Chuyên ngành :"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="txtchuyennganh" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            <asp:Label ID="Label4" runat="server" Text="Trình độ chuyên môn :"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="txttrinhdochuyenmon" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            <asp:Label ID="Label5" runat="server" Text="Sở trường :"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="txtsotruong" runat="server" Width="199px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            <asp:Label ID="Label6" runat="server" Text="Tổ :"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:DropDownList ID="ddlmato" runat="server" DataTextField="Tên tổ" DataValueField="Mã tổ">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            <asp:Label ID="Label7" runat="server" Text="Ngày sinh :"></asp:Label>
                        </td>
                        <td align="center" class="style21">
                            <dxe:ASPxDateEdit ID="txtDate" runat="server" Width="180px">
                            </dxe:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="style20">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Sửa" Width="114px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" OnClick="btnCancel_Click"
                                Text="Hủy" Width="129px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="style20">
                            <asp:Button ID="btnthem" runat="server" Text="Lưu" OnClick="btnthem_Click" Width="120px" />
                            &nbsp;
                            <asp:Button ID="btnhuy" runat="server" Text="Hủy" OnClick="btnhuy_Click" Width="129px" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <br />
        </asp:MultiView>
    </div>
</asp:Content>
