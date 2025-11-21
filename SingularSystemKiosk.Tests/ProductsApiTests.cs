

public class ProductsControllerTests
{
    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingularSystemKiosk.Controllers;
using SingularSystemKiosk.Data;
using SingularSystemKiosk.Dtos.ProductsDto;
using SingularSystemKiosk.Models;
    [Fact]
    public async Task GetAllProducts_ReturnsOk_WhenNoProductsAvailable()
    {

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;


        var dbContext = new AppDbContext(options);

        var controller = new ProductsController(dbContext, null, null, null);


        var result = await controller.GetAllProducts();


        Assert.IsType<OkObjectResult>(result);
    }
    [Fact]
    public async Task GetProductById_ReturnsBadRequest_WhenIdIsZero()
    {
        
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;


        var dbContext = new AppDbContext(options);

        var controller = new ProductsController(dbContext, null, null, null);

  
        var result = await controller.GetProductById(0);

       
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb2")
            .Options;
        var dbContext = new AppDbContext(options);

        var controller = new ProductsController(dbContext, null, null, null);

        var result = await controller.GetProductById(999);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetProductById_ReturnsOk_WhenProductExists()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb4")
            .Options;
        var dbContext = new AppDbContext(options);

        dbContext.Products.Add(new Products { Id = 1, Name = "Test Product" });
        dbContext.SaveChanges();

        var controller = new ProductsController(dbContext, null, null, null);

        var result = await controller.GetProductById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }


    [Fact]
    public async Task AddProducts_ReturnsCreated_WhenProductAdded()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb3")
            .Options;
        var dbContext = new AppDbContext(options);

        var controller = new ProductsController(dbContext, null, null, null);

        var result = await controller.AddProducts(new CreateProductDto { Name="Ayanda",Available=true,Price=0.9M});

        var okResult = Assert.IsType<CreatedAtActionResult>(result);
        
    }
    [Fact]
    public async Task AddProducts_ReturnsBadRequest_WhenProductHasBadData()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb3")
            .Options;
        var dbContext = new AppDbContext(options);

        var controller = new ProductsController(dbContext, null, null, null);
        controller.ModelState.AddModelError("Name", "Required");
        var result = await controller.AddProducts(new CreateProductDto { Name = "", Available = true, Price = 0.9M, });

        var okResult = Assert.IsType<BadRequestObjectResult>(result);

    }
    [Fact]
    public async Task EditProducts_ReturnsBadRequest_WhenProductHasBadData()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb3")
            .Options;



        var dbContext = new AppDbContext(options);

        dbContext.Products.Add(new Products { Id = 1, Name = "Test Product" });
        dbContext.SaveChanges();
        var controller = new ProductsController(dbContext, null, null, null);
        controller.ModelState.AddModelError("Name", "Required");
        var result = await controller.UpdateProducts(1,new UpdateProductDto { Name = "", Available = true, Price = 0.9M, });

        var okResult = Assert.IsType<BadRequestObjectResult>(result);

    }
    [Fact]
    public async Task EditProducts_ReturnsOk_WhenProductHasBeenUpdated()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb3")
            .Options;



        var dbContext = new AppDbContext(options);

        dbContext.Products.Add(new Products { Id = 1, Name = "Test Product" });
        dbContext.SaveChanges();
        var controller = new ProductsController(dbContext, null, null, null);
       

        var result = await controller.UpdateProducts(1, new UpdateProductDto { Name = "Ayanda",Quantity=4, Available = true, Price = 0.9M, });

        var okResult = Assert.IsType<OkObjectResult>(result);

    }
    [Fact]
    public async Task DeleteProducts_NotFound_WhenProductDoesNotExist()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb3")
            .Options;



        var dbContext = new AppDbContext(options);

        var controller = new ProductsController(dbContext, null, null, null);


        var result = await controller.DeleteProducts(400);

        var okResult = Assert.IsType<NotFoundResult>(result);

    }
    [Fact]
    public async Task DeleteProducts_ReturnsOk_WhenProductExists()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb3")
            .Options;



        var dbContext = new AppDbContext(options);

        var controller = new ProductsController(dbContext, null, null, null);
        int id=1;
        dbContext.Products.Add(new Products { Id = id, Name = "Test Product" });
        dbContext.SaveChanges();
        var result = await controller.DeleteProducts(1);

        var okResult = Assert.IsType<OkObjectResult>(result);

    }





}
