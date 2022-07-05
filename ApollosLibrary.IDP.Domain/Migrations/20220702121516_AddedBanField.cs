using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Migrations
{
    public partial class AddedBanField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("24f54865-07ef-4384-86ee-cf3ac0156df4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("34d726a7-cdd0-4539-b2cd-bd98f920567d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("3e19e864-9799-4563-967c-2f34e28392a7"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("ec6da4da-d04a-4250-acd0-6ce1f9f1ce21"));

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "ClientSecretId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 7, 2, 22, 15, 15, 779, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "UserClaimId", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("711864cf-682d-45e4-ae36-db2f13a3fffc"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "moderator" },
                    { new Guid("9eb7b29f-f5a8-493d-bc0f-29c89ffa2be8"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "administrator" },
                    { new Guid("e61173c3-4772-4fa6-900c-f3e7fce5a9f2"), "emailaddress", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "wados.russell70@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"),
                columns: new[] { "CreatedDate", "Subject" },
                values: new object[] { new DateTime(2022, 7, 2, 22, 15, 15, 778, DateTimeKind.Local).AddTicks(9874), "152807d6-710c-4380-9e26-014d06745953" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("711864cf-682d-45e4-ae36-db2f13a3fffc"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("9eb7b29f-f5a8-493d-bc0f-29c89ffa2be8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("e61173c3-4772-4fa6-900c-f3e7fce5a9f2"));

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "ClientSecretId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "UserClaimId", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("24f54865-07ef-4384-86ee-cf3ac0156df4"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "administrator" },
                    { new Guid("34d726a7-cdd0-4539-b2cd-bd98f920567d"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "moderator" },
                    { new Guid("3e19e864-9799-4563-967c-2f34e28392a7"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "freeaccount" },
                    { new Guid("ec6da4da-d04a-4250-acd0-6ce1f9f1ce21"), "email", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "wados.russell70@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"),
                columns: new[] { "CreatedDate", "Subject" },
                values: new object[] { new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2086), "2a53123c-7a2b-406a-9b2a-c263cce33fd4" });
        }
    }
}
