<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="PhanLop.aspx.cs" Inherits="Admin_PhanLop" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <p>
        &nbsp;</p>
    
    <asp:Panel ID="panelKPL" runat="server" GroupingText="Kiểu phân lớp">
        <div ID="dvHSMoilencap" align="left">
            Phân lớp cho HS mới lên cấp/HS cũ:</div>
        
        <asp:RadioButtonList ID="rdlistHSLC" runat="server" AutoPostBack="True" 
            Height="35px" RepeatDirection="Horizontal" ForeColor="#FF3300" 
            onselectedindexchanged="rdlistHSLC_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="HS Lên Cấp">Phân Lớp Cho HS Mới Lên Cấp</asp:ListItem>
            <asp:ListItem Value="HS Cũ">Phân Lớp CHo HS Cũ</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Panel ID="pnlHeadHSLB" runat="server">
        <div>
            <div ID="dvLuuban" align="left">
                Phân lớp cho HS được lên lớp/HS lưu ban:</div>
            <asp:RadioButtonList ID="rdlistLB" runat="server" AutoPostBack="True" 
                RepeatDirection="Horizontal" ForeColor="#009900" Height="35px">
                <asp:ListItem Selected="True" Value="HS Được Lên Lớp">Phân Lớp Cho HS Được Lên 
                Lớp</asp:ListItem>
                <asp:ListItem Value="HS Lưu Ban">Phân Lớp Cho HS Lưu Ban</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        </asp:Panel>
        <asp:Panel ID="pnlHeadKPL" runat="server">
        <div ID="dvKieuphanlop" align="left">
            Chọn kiểu Phân lớp:</div>
            <asp:RadioButtonList ID="rdlistKPL" runat="server" AutoPostBack="True" 
                EnableTheming="True" RepeatDirection="Horizontal" ForeColor="#3333CC">
                <asp:ListItem Selected="True">Tự Động</asp:ListItem>
                <asp:ListItem>Thủ Công</asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>    
    </asp:Panel>
    <asp:Panel ID="pnlHSMoilencap" runat="server" GroupingText="HS mới Lên Cấp" 
        onload="pnlHSMoilencap_Load">
        <asp:Label ID="Label2" runat="server" Text="Niên Khóa:  "></asp:Label>
        <asp:DropDownList ID="drlNamhoc0" runat="server" EnableTheming="True" 
            AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <div ID="grvhocsinhlencap" align=center>
        <asp:GridView ID="grdvHSLencap" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="MaHS" onload="grdvHSLencap_Load" 
            onselectedindexchanged="grdvHSLencap_SelectedIndexChanged" 
            Width="800px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="STT" InsertVisible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbSTT" runat="server" Text='<%# Eval("STT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mã HS" InsertVisible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbMaHS" runat="server" Text='<%# Eval("MaHS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Họ Tên">
                    <ItemTemplate>
                        <asp:Label ID="ltHoTen" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Điểm Cuối Cấp">
                    <ItemTemplate>
                        <asp:Label ID="lbDTB" runat="server" Text='<%# Eval("DTB") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hạnh Kiểm Cuối Cấp">
                    <ItemTemplate>
                        <asp:Label ID="lbHanhKiem" runat="server" Text='<%# Eval("HanhKiem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
            <br />
        </div>
        <asp:Button ID="btPhanLopTD" runat="server" Text="Bắt đầu phân lớp" 
            onclick="btPhanLopTD_Click" />
    </asp:Panel>
    
    <asp:Panel ID="pnlHSDuoclenlop" runat="server" GroupingText="HS Được Lên Lớp" 
        style="margin-top: 0px">
        <asp:Label ID="Label3" runat="server" Text="Năm học cũ:"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="drlNamHocCuLL" runat="server" AutoPostBack="True" 
            onselectedindexchanged="drlNamHocTD_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Khối lớp cũ:"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="drlKhoiLopCuLL" runat="server" Height="16px" 
            AutoPostBack="True" 
            onselectedindexchanged="drlKhoiLopCuTD_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Năm học mới:"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="drlNamHocMoiLL" runat="server" AutoPostBack="True" 
            onselectedindexchanged="drlNamHocMoiLL_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Khối lớp mới:"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="drlKhoiLopMoiLL" runat="server" AutoPostBack="True" 
            Height="16px" onselectedindexchanged="drlKhoiLopMoiLL_selectchange">
        </asp:DropDownList>
    <asp:Panel ID="pnlTudong" runat="server">
        
        <div align="left">
            Phân lớp tự động<asp:GridView ID="grdvHSCu_TuDong" runat="server" 
                AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
                ForeColor="#333333" GridLines="None" onload="grdvHSLencap_Load" 
                onselectedindexchanged="grdvHSLencap_SelectedIndexChanged" Width="800px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" InsertVisible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbSTT0" runat="server" Text='<%# Eval("STT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mã HS" InsertVisible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbMaHS0" runat="server" Text='<%# Eval("MaHS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Họ Tên">
                        <ItemTemplate>
                            <asp:Label ID="ltHoTen0" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lớp">
                        <ItemTemplate>
                            <asp:DropDownList ID="drlLop" runat="server" AutoPostBack="True" 
                                DataSource="<%# getDatatableLop() %>" DataTextField='<%# Eval("MaLop") %>' 
                                DataValueField='<%# Eval("TenLop") %>'>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
        
    </asp:Panel>
    <asp:Panel ID="pnlThucong" runat="server">
        <div align="left">
            Phân lớp thủ công<asp:GridView ID="grdvHSCuThuCong" runat="server" 
                AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
                ForeColor="#333333" GridLines="None" onload="grdvHSLencap_Load" 
                onselectedindexchanged="grdvHSLencap_SelectedIndexChanged" Width="800px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" InsertVisible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbSTT1" runat="server" Text='<%# Eval("STT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mã HS" InsertVisible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbMaHS1" runat="server" Text='<%# Eval("MaHS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Họ Tên">
                        <ItemTemplate>
                            <asp:Label ID="ltHoTen1" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </asp:Panel>
    </asp:Panel>
        
    <asp:Panel ID="pnlHSLuuban" runat="server" GroupingText="HS Lưu Ban" 
        Visible="False">
        <asp:GridView ID="grdvHSCuLuuBan" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" onload="grdvHSLencap_Load" 
            onselectedindexchanged="grdvHSLencap_SelectedIndexChanged" Width="800px">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="STT" InsertVisible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbSTT2" runat="server" Text='<%# Eval("STT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mã HS" InsertVisible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbMaHS2" runat="server" Text='<%# Eval("MaHS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Họ Tên">
                    <ItemTemplate>
                        <asp:Label ID="ltHoTen2" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Button2" 
            onclick="Button1_Click" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </asp:Panel>
</asp:Content>

