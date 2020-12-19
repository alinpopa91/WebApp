import { SearchForm } from "../SearchForm";
import {
  createFeatureSelector,
  createSelector,
  createReducer,
  on
} from '@ngrx/store';
import { setLoading } from "../actions/home.actions";

export interface State {
  isLoading: boolean
}

export const initialState: State = {
  isLoading: true
};

const _homeAppReducer = createReducer(
  initialState,
  on(setLoading, (state, action) => ({
    ...state,
    isLoading: action.isLoading
  }))

);


const getLayoutState = createFeatureSelector<State>('layout');

export const getIsSearchLoading = createSelector(
  getLayoutState,
  state => state.isLoading
);


export function homeAppReducer(state: State, action: any) {
  return _homeAppReducer(state, action);
}

