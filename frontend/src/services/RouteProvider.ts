const RouteProvider = {
    getAddRoute: () => process.env.REACT_APP_API + "/calc/add",
    getSubRoute: () => process.env.REACT_APP_API + "/calc/sub",
    getMulRoute: () => process.env.REACT_APP_API + "/calc/mul",
    getDivRoute: () => process.env.REACT_APP_API + "/calc/div",
    getPowRoute: () => process.env.REACT_APP_API + "/calc/pow",
    getRootRoute: () => process.env.REACT_APP_API + "/calc/root",
    getExprRoute: () => process.env.REACT_APP_API + "/calc/expr"
}

export default RouteProvider