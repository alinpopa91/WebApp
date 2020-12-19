"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var store_1 = require("@ngrx/store");
exports.setLoading = store_1.createAction('[Main] isLoading', store_1.props());
var actions = store_1.union({
    setLoading: exports.setLoading
});
//# sourceMappingURL=home.actions.js.map