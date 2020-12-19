"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var store_1 = require("@ngrx/store");
var home_actions_1 = require("../actions/home.actions");
exports.initialState = {
    isLoading: true
};
var _homeAppReducer = store_1.createReducer(exports.initialState, store_1.on(home_actions_1.setLoading, function (state, action) { return (__assign(__assign({}, state), { isLoading: action.isLoading })); }));
var getLayoutState = store_1.createFeatureSelector('layout');
exports.getIsSearchLoading = store_1.createSelector(getLayoutState, function (state) { return state.isLoading; });
function homeAppReducer(state, action) {
    return _homeAppReducer(state, action);
}
exports.homeAppReducer = homeAppReducer;
//# sourceMappingURL=home.reducers.js.map