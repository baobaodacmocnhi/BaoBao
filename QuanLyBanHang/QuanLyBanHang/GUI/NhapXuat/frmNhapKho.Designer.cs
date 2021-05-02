﻿namespace QuanLyBanHang.GUI.NhapXuat
{
    partial class frmNhapKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCoHoaDon = new System.Windows.Forms.CheckBox();
            this.chkNhanVienGiuTien = new System.Windows.Forms.CheckBox();
            this.txtNhanVienSoTien = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_NK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKhachHang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkChuyenKhoan = new System.Windows.Forms.CheckBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNiemYet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaGiamTrucTiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaGiamTyLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThucTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThucTra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(92, 15);
            this.dateNgayLap.Margin = new System.Windows.Forms.Padding(4);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(125, 22);
            this.dateNgayLap.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ngày Lập";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNhanVien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(92, 47);
            this.cmbNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(132, 24);
            this.cmbNhanVien.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Nhân Viên";
            // 
            // chkCoHoaDon
            // 
            this.chkCoHoaDon.AutoSize = true;
            this.chkCoHoaDon.Location = new System.Drawing.Point(92, 80);
            this.chkCoHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.chkCoHoaDon.Name = "chkCoHoaDon";
            this.chkCoHoaDon.Size = new System.Drawing.Size(107, 21);
            this.chkCoHoaDon.TabIndex = 25;
            this.chkCoHoaDon.Text = "Có Hóa Đơn";
            this.chkCoHoaDon.UseVisualStyleBackColor = true;
            // 
            // chkNhanVienGiuTien
            // 
            this.chkNhanVienGiuTien.AutoSize = true;
            this.chkNhanVienGiuTien.Location = new System.Drawing.Point(232, 49);
            this.chkNhanVienGiuTien.Margin = new System.Windows.Forms.Padding(4);
            this.chkNhanVienGiuTien.Name = "chkNhanVienGiuTien";
            this.chkNhanVienGiuTien.Size = new System.Drawing.Size(154, 21);
            this.chkNhanVienGiuTien.TabIndex = 26;
            this.chkNhanVienGiuTien.Text = "Nhân Viên Giữ Tiền";
            this.chkNhanVienGiuTien.UseVisualStyleBackColor = true;
            // 
            // txtNhanVienSoTien
            // 
            this.txtNhanVienSoTien.Location = new System.Drawing.Point(557, 47);
            this.txtNhanVienSoTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhanVienSoTien.Name = "txtNhanVienSoTien";
            this.txtNhanVienSoTien.Size = new System.Drawing.Size(132, 22);
            this.txtNhanVienSoTien.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(394, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Số Tiền Nhân Viên Giữ";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1041, 82);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 28);
            this.btnSua.TabIndex = 49;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1041, 46);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 28);
            this.btnXoa.TabIndex = 48;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1041, 11);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 28);
            this.btnThem.TabIndex = 47;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "Danh Sách Linh Kiện";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowDrop = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.KyHieu,
            this.HoTen,
            this.SoLuong,
            this.GiaNCC,
            this.GiaNiemYet,
            this.GiaGiamTrucTiep,
            this.GiaGiamTyLe,
            this.TongCong,
            this.ThucTra});
            this.dgvSanPham.Location = new System.Drawing.Point(17, 124);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.Size = new System.Drawing.Size(1124, 638);
            this.dgvSanPham.TabIndex = 54;
            this.dgvSanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSanPham_CellFormatting);
            this.dgvSanPham.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellValueChanged);
            this.dgvSanPham.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSanPham_EditingControlShowing);
            this.dgvSanPham.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSanPham_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.dateDen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1149, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(752, 758);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Nhập Kho";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowDrop = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayLap,
            this.KhachHang,
            this.TongCong_NK});
            this.dgvDanhSach.Location = new System.Drawing.Point(8, 55);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(723, 623);
            this.dgvDanhSach.TabIndex = 55;
            this.dgvDanhSach.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhSach_CellFormatting);
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày Lập";
            this.NgayLap.Name = "NgayLap";
            // 
            // KhachHang
            // 
            this.KhachHang.DataPropertyName = "KhachHang";
            this.KhachHang.HeaderText = "Khách Hàng";
            this.KhachHang.Name = "KhachHang";
            // 
            // TongCong_NK
            // 
            this.TongCong_NK.DataPropertyName = "TongCong";
            this.TongCong_NK.HeaderText = "Tổng Cộng";
            this.TongCong_NK.Name = "TongCong_NK";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(448, 22);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 28);
            this.btnXem.TabIndex = 48;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(313, 25);
            this.dateDen.Margin = new System.Windows.Forms.Padding(4);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(125, 22);
            this.dateDen.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Đến Ngày";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(97, 23);
            this.dateTu.Margin = new System.Windows.Forms.Padding(4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(125, 22);
            this.dateTu.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Từ Ngày";
            // 
            // cmbKhachHang
            // 
            this.cmbKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKhachHang.FormattingEnabled = true;
            this.cmbKhachHang.Location = new System.Drawing.Point(324, 14);
            this.cmbKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKhachHang.Name = "cmbKhachHang";
            this.cmbKhachHang.Size = new System.Drawing.Size(265, 24);
            this.cmbKhachHang.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "Khách Hàng";
            // 
            // chkChuyenKhoan
            // 
            this.chkChuyenKhoan.AutoSize = true;
            this.chkChuyenKhoan.Location = new System.Drawing.Point(206, 80);
            this.chkChuyenKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.chkChuyenKhoan.Name = "chkChuyenKhoan";
            this.chkChuyenKhoan.Size = new System.Drawing.Size(205, 21);
            this.chkChuyenKhoan.TabIndex = 59;
            this.chkChuyenKhoan.Text = "Thanh Toán Chuyển Khoản";
            this.chkChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // KyHieu
            // 
            this.KyHieu.DataPropertyName = "KyHieu";
            this.KyHieu.HeaderText = "Mã SP";
            this.KyHieu.Name = "KyHieu";
            this.KyHieu.Width = 70;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Sản Phẩm";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 80;
            // 
            // GiaNCC
            // 
            this.GiaNCC.DataPropertyName = "GiaNCC";
            this.GiaNCC.HeaderText = "Giá Nhà Cung Cấp";
            this.GiaNCC.Name = "GiaNCC";
            // 
            // GiaNiemYet
            // 
            this.GiaNiemYet.DataPropertyName = "GiaNiemYet";
            this.GiaNiemYet.HeaderText = "Giá Niêm Yết";
            this.GiaNiemYet.Name = "GiaNiemYet";
            // 
            // GiaGiamTrucTiep
            // 
            this.GiaGiamTrucTiep.DataPropertyName = "GiaGiamTrucTiep";
            this.GiaGiamTrucTiep.HeaderText = "Giá Giảm Trực Tiếp";
            this.GiaGiamTrucTiep.Name = "GiaGiamTrucTiep";
            // 
            // GiaGiamTyLe
            // 
            this.GiaGiamTyLe.DataPropertyName = "GiaGiamTyLe";
            this.GiaGiamTyLe.HeaderText = "Giảm Tỷ Lệ";
            this.GiaGiamTyLe.Name = "GiaGiamTyLe";
            this.GiaGiamTyLe.Width = 50;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            // 
            // ThucTra
            // 
            this.ThucTra.DataPropertyName = "ThucTra";
            this.ThucTra.HeaderText = "Thực Trả";
            this.ThucTra.Name = "ThucTra";
            // 
            // txtTongCong
            // 
            this.txtTongCong.Location = new System.Drawing.Point(783, 17);
            this.txtTongCong.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(132, 22);
            this.txtTongCong.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(697, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Tổng Cộng";
            // 
            // txtThucTra
            // 
            this.txtThucTra.Location = new System.Drawing.Point(783, 47);
            this.txtThucTra.Margin = new System.Windows.Forms.Padding(4);
            this.txtThucTra.Name = "txtThucTra";
            this.txtThucTra.Size = new System.Drawing.Size(132, 22);
            this.txtThucTra.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(697, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Thực Trả";
            // 
            // frmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 777);
            this.Controls.Add(this.txtThucTra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkChuyenKhoan);
            this.Controls.Add(this.cmbKhachHang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNhanVienSoTien);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkNhanVienGiuTien);
            this.Controls.Add(this.chkCoHoaDon);
            this.Controls.Add(this.dateNgayLap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNhapKho";
            this.Text = "Nhập Kho";
            this.Load += new System.EventHandler(this.frmNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCoHoaDon;
        private System.Windows.Forms.CheckBox chkNhanVienGiuTien;
        private System.Windows.Forms.TextBox txtNhanVienSoTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.ComboBox cmbKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_NK;
        private System.Windows.Forms.CheckBox chkChuyenKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNiemYet;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaGiamTrucTiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaGiamTyLe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThucTra;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThucTra;
        private System.Windows.Forms.Label label6;

    }
}