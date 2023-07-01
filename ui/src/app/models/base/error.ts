export interface Error {
  isSuccess: boolean;
  type: string;
  title: string;
  status: number;
  detail: string;
  instance: string;
  extensions: {};
}
