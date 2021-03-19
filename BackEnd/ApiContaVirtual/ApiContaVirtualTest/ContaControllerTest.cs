using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiContaVirtualTest
{
    public class ContaControllerTest
    {
        ContaControllerTest _controller;
        ICompraService _service;
        public ComprasControllerTest()
        {
            _service = new CompraServiceFake();
            _controller = new ComprasController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<CompraItem>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
