using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Sagaru.Models;

namespace Sagaru.Migrations
{
    [DbContext(typeof(SagaruDbContext))]
    [Migration("20160422165513_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sagaru.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ProjectId");
                });

            modelBuilder.Entity("Sagaru.Models.Shape", b =>
                {
                    b.Property<int>("Shapeid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<string>("Type");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Shapeid");
                });

            modelBuilder.Entity("Sagaru.Models.Shape", b =>
                {
                    b.HasOne("Sagaru.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });
        }
    }
}
