using ReadExcel.AttributeCustome;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadExcel.Model
{
    [Table("Master_List")]
    public class DataEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Product_No")]
        [Excel("Product No")]
        public string? Product_No { get; set; }
        [Column("PCAModuleAndInternal")]
        [Excel("PCA, Module and Internal P/N")]
        public string? PCAModuleAndInternal { get; set; }
        [Column("KCC")]
        [Excel("KCC")]
        public string? KCC { get; set; }
        [Column("StandardPackQty")]
        [Excel("Standard Pack Qty")]
        public string? StandardPackQty { get; set; }
        [Column("ProductDescriptione")]
        [Excel("Product Description")]
        public string? ProductDescriptione { get; set; }
        [Column("DigitsUPCCode")]
        [Excel("12 digits UPC-Code")]
        public string? DigitsUPCCode { get; set; }
        [Column("digitsJANCode")]
        [Excel("13 digits JAN-Code")]
        public string? digitsJANCode { get; set; }
        [Column("rev")]
        [Excel("rev")]
        public string? Rev { get; set; }
        [Column("RMN")]
        [Excel("RMN")]
        public string? RMN { get; set; }
        [Column("ProductLabelTemplate")]
        [Excel("Product Label  Tem[plate  106128-011")]
        public string? ProductLabelTemplate { get; set; }
        [Column("HPInternalPN")]
        [Excel("HP Internal P/N")]
        public string? HPInternalPN { get; set; }
        [Column("OverpackLabelTemplate")]
        [Excel("Overpack Label Template 106128-011")]
        public string? OverpackLabelTemplate { get; set; }
        [Column("ImprintLogo")]
        [Excel("Imprint Logo")]
        public string? ImprintLogo { get; set; }
        [Column("ImprintSerialNo")]
        [Excel("Imprint Serial No")]
        public string? ImprintSerialNo { get; set; }
        [Column("UpdatedBy")]
        [Excel("Updated By")]
        public string? UpdatedBy { get; set; }
        [Column("DateOfUpdated")]
        [Excel("Date of updated")]
        public DateTime DateOfUpdated { get; set; }
        [Column("ProductCode")]
        [Excel("Product Code")]
        public string? ProductCode { get; set; }
        [Column("Remark1")]
        [Excel("Remark")]
        public string? Remark { get; set; }
        [Column("BISNumber")]
        [Excel("BIS Number (Yes)?")]
        public string? BISNumber { get; set; }
        [Column("SamePartSNCheck")]
        [Excel("Same Part SN Check (Yes)")]
        public string? SamePartSNCheck { get; set; }
        [Column("SupplierPartNumber")]
        [Excel("Supplier part number")]
        public string? SupplierPartNumber { get; set; }
        [Column("OptionPN")]
        [Excel("Option PN")]
        public string? OptionPN { get; set; }
        [Column("SpareNo")]
        [Excel("Spare No.")]
        public string? SpareNo { get; set; }
        [Column("MaterialNo")]
        [Excel("Material No (CDC FERT)")]
        public string? MaterialNo { get; set; }
        [Column("CDCLabelTemplate")]
        [Excel("CDC Label Tem[plate  106128-011")]
        public string? CDCLabelTemplate { get; set; }
    }
}
