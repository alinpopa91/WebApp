import { createAction, props, union } from "@ngrx/store";

export const setLoading = createAction(
  '[Main] isLoading',
  props<{ isLoading: boolean }>()
  );

const actions = union({
  setLoading
});

export type Actions = typeof actions;
