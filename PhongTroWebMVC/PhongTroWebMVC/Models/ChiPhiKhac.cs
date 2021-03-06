﻿namespace PhongTroWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiPhiKhac")]
    public partial class ChiPhiKhac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiPhiKhac()
        {
            ChiPhiPhongs = new HashSet<ChiPhiPhong>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Chi phí khác")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Giá tiền")]
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:#,##}", ApplyFormatInEditMode = true)]
        public int? GiaTien { get; set; }

        [Display(Name="Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifyDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiPhiPhong> ChiPhiPhongs { get; set; }
    }
}
