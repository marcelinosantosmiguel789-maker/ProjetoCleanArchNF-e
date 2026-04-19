using System.Net;
using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using CleanArchWebUINFe;
using CleanArchNFeApplication.DTOs;
using System.Threading.Tasks;
using FluentAssertions;
using System.Collections.Generic;

namespace CleanArchWebUINFe.Tests
{
    public class NotaFiscalControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public NotaFiscalControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetById_NotFound_Returns404()
        {
            var client = _factory.CreateClient();

            var resp = await client.GetAsync("/api/notafiscal/99999");

            resp.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task AddItem_InvalidModel_ReturnsBadRequest()
        {
            var client = _factory.CreateClient();

            var item = new ItemNotaFiscalDTO(); // invalid model

            var resp = await client.PostAsJsonAsync("/api/notafiscal/1/itens", item);

            resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
