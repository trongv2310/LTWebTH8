namespace LTWeb08_Bai02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CHITIETDONDATHANG = new HashSet<CHITIETDONDATHANG>();
            VIETSACH = new HashSet<VIETSACH>();
        }

        [Key]
        [Display(Name = "Mã Sách")]
        public int MaSach { get; set; }

        [StringLength(200)]
        [Display(Name = "Tên Sách")]
        public string TenSach { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Giá Bán")]
        public decimal? GiaBan { get; set; }

        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }

        [StringLength(255)]
        [Display(Name = "Ảnh Bìa")]
        public string AnhBia { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày Cập Nhật")]
        public DateTime? NgayCapNhat { get; set; }

        [Display(Name = "Số Lượng Tồn")]
        public int? SoLuongTon { get; set; }

        [Display(Name = "Mã Chủ Đề")]
        public int? MaCD { get; set; }

        [Display(Name = "Mã Nhà Xuất Bản")]
        public int? MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONDATHANG> CHITIETDONDATHANG { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIETSACH> VIETSACH { get; set; }
    }
}