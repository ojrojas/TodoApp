module.exports = {
  "/identity": {
    target:
      process.env["services__identity__https__0"] ||
      process.env["services__identity__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/identity": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
  "/todo": {
    target:
      process.env["services__todo__https__0"] ||
      process.env["services__todo__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/todo": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
  "/seq": {
    target:
      process.env["ConnectionStrings__seq"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/seq": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },


};
console.log(module.exports);
