# 说明

此项目是通过Web API构建的http服务 , 为cook配套后端代码，[前端代码在这](https://github.com/SeaBiscuit-Z/cook), 

# 技术栈

三层 （D-B-M） + asp.net mvc WebApi + cors 跨域 + sqlserver

# 项目运行

1.  WebApi / Web.config   第15行 ， 设置你自己的数据库连接字符串
```
<add key="ConnectionString" value="server=.;database=cooking;uid=sa;pwd=123;"/> //这是我的，修改value里的值即可
```

1.  WebApi / Web.config   第82行 ， 设置自己的前端路径
```
<add name="Access-Control-Allow-Origin" value="http://localhost:8080" /> // 这是我的，修改value里的值即可
```


# 项目文件布局

```
.
├── BLL                                 // 数据处理层
├── DAL                                 // 数据访问层
├── DB                                  // 数据库文件
├── DBUtility                           // 数据库连接类库
├── Lib                                 // 需要引用的系统类库
├── Model                               // 数据库表模型
├── Views                               // 数据模型
├── WebApi                              // WebApi
│   ├── App_Start                       // Global.asax配置
│   ├── Controllers                     // 返回数据的控制器
│   ├── Models                          // token 数据结构类
│   ├── Properties                      // 特性集
│   ├── common                          // 公共方法类
│   ├── AuthFilterOutside.cs            // token 验证
│   ├── CrossSiteAttribute.cs           // 跨域设置
│   ├── Global.asax                     // 全局配置文件
│   ├── img.ashx                        // 生成验证码
│   └── Web.config                      // 站点配置文件
├── packages                            // 需要引用的系统类库
├── CookApi.sln
└── CookApi.suo
.
```  
