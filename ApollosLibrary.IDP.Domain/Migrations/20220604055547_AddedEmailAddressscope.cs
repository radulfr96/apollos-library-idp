using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Migrations
{
    public partial class AddedEmailAddressscope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("2c916445-93aa-4e37-8607-07b02736f719"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("3c48d7df-8899-45a4-a651-489449b55fa6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("72531613-e5e6-4090-bb60-d231664ff0f0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "UserClaimId",
                keyValue: new Guid("d66bb188-3795-4693-bae0-3a5f1c214d39"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("2cd58a94-03c0-486b-9a64-95ecb2bb4666"));

            migrationBuilder.InsertData(
                table: "ApiResourceClaims",
                columns: new[] { "ApiResourceClaimId", "ApiResourceId", "Type" },
                values: new object[] { 3, 1, "emailaddress" });

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
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"), new DateTime(2022, 6, 4, 15, 55, 46, 99, DateTimeKind.Local).AddTicks(8566), true, null, null, "AQAAAAEAACcQAAAAECY64tCZ5CSbcXzOp4NE6XAr1TB9wQ1zgMv6Sa49QGTmEftnFXzPMsBH+NB1cu5brw==", null, null, "9cec37de-0238-4038-b1cd-cd4f50b36412", "radulfr" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApiResourceClaims",
                keyColumn: "ApiResourceClaimId",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e7f12974-73dd-48d6-aa79-95fe1ded101e"));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "ApiResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(132));

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
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "IdentityResourceId",
                keyValue: 6,
                columns: new[] { "Created", "Name" },
                values: new object[] { new DateTime(2022, 3, 13, 14, 53, 39, 161, DateTimeKind.Local).AddTicks(341), "email" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("2cd58a94-03c0-486b-9a64-95ecb2bb4666"), new Guid("2cd58a94-03c0-486b-9a64-95ecb2bb4666"), new DateTime(2022, 3, 13, 14, 53, 39, 160, DateTimeKind.Local).AddTicks(9881), true, null, null, "AQAAAAEAACcQAAAAECY64tCZ5CSbcXzOp4NE6XAr1TB9wQ1zgMv6Sa49QGTmEftnFXzPMsBH+NB1cu5brw==", null, null, "eec62170-997c-48ab-b56c-5705f4c7567a", "radulfr" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "UserClaimId", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("2c916445-93aa-4e37-8607-07b02736f719"), "role", new Guid("2cd58a94-03c0-486b-9a64-95ecb2bb4666"), "administrator" },
                    { new Guid("3c48d7df-8899-45a4-a651-489449b55fa6"), "emailaddress", new Guid("2cd58a94-03c0-486b-9a64-95ecb2bb4666"), "wados.russell70@gmail.com" },
                    { new Guid("72531613-e5e6-4090-bb60-d231664ff0f0"), "role", new Guid("2cd58a94-03c0-486b-9a64-95ecb2bb4666"), "freeaccount" },
                    { new Guid("d66bb188-3795-4693-bae0-3a5f1c214d39"), "role", new Guid("2cd58a94-03c0-486b-9a64-95ecb2bb4666"), "moderator" }
                });
        }
    }
}
