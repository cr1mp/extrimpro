namespace xrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SamaryIntToLong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vacancies", "SalaryMinRub", c => c.Long(nullable: false));
            AlterColumn("dbo.Vacancies", "SalaryMaxRub", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vacancies", "SalaryMaxRub", c => c.Int(nullable: false));
            AlterColumn("dbo.Vacancies", "SalaryMinRub", c => c.Int(nullable: false));
        }
    }
}
