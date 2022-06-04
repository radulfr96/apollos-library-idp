using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Migrations
{
    public partial class UpdateEmailAddressScope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("4224dd91-ca99-4b36-8ac4-f5db4bf385b6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("48a8efe7-7a77-4ba8-bf4d-a59a4ef9d163"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("719ebb72-8b63-475b-b505-fc4f74a77db3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("d61bfa7f-6222-497a-86c1-cfcfc6bd0be2"));

            migrationBuilder.UpdateData(
                table: "ApiResourceClaims",
                keyColumn: "ApiResourceClaimId",
                keyValue: 3,
                column: "Type",
                value: "email");

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
                table: "ClientScopes",
                keyColumn: "ClientScopeId",
                keyValue: 6,
                column: "Scope",
                value: "email");

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
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2022, 6, 4, 16, 41, 33, 916, DateTimeKind.Local).AddTicks(2522), "email" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "ApiResourceClaims",
                keyColumn: "ApiResourceClaimId",
                keyValue: 3,
                column: "Type",
                value: "emailaddress");

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "ClientScopes",
                keyColumn: "ClientScopeId",
                keyValue: 6,
                column: "Scope",
                value: "emailaddress");

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "ClientSecretId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 6,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(9003), "emailaddress" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "UserClaimId", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("4224dd91-ca99-4b36-8ac4-f5db4bf385b6"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "moderator" },
                    { new Guid("48a8efe7-7a77-4ba8-bf4d-a59a4ef9d163"), "emailaddress", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "wados.russell70@gmail.com" },
                    { new Guid("719ebb72-8b63-475b-b505-fc4f74a77db3"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "freeaccount" },
                    { new Guid("d61bfa7f-6222-497a-86c1-cfcfc6bd0be2"), "role", new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), "administrator" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"),
                columns: new[] { "CreatedDate", "Subject" },
                values: new object[] { new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8566), "9cec37de-0238-4038-b1cd-cd4f50b36412" });
        }
    }
}
