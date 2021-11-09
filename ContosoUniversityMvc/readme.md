
# Markdown File

[教程：在ASP.NET MVC Web 应用中使用 EF Core 入门](https://docs.microsoft.com/zh-cn/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0)


### 读取一个实体的方法
生成的代码使用 FirstOrDefaultAsync 读取一个实体。 如果未找到任何内容，则此方法返回 NULL；否则，它将返回满足查询筛选条件的第一行。 FirstOrDefaultAsync 通常是比以下备选方案更好的选择：
- SingleOrDefaultAsync - 如果有多个满足查询筛选器的实体，则引发异常。 若要确定查询是否可以返回多行，SingleOrDefaultAsync 会尝试提取多个行。 如果查询只能返回一个实体，就像它在搜索唯一键时一样，那么该额外工作是不必要的。
- FindAsync - 查找具有主键 ( PK) 的实体。 如果具有 PK 的实体正在由上下文跟踪，会返回该实体且不向数据库发出请求。 此方法经过优化，可查找单个实体，但无法通过 FindAsync 调用 Include。 如果需要相关数据，FirstOrDefaultAsync 则是更好的选择。


https://docs.microsoft.com/zh-cn/aspnet/core/data/ef-mvc/crud?view=aspnetcore-5.0