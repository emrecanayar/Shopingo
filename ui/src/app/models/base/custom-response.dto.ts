export interface CustomResponseDto<T> {
    data: T;
    statusCode?: number;
    isSuccess?: boolean;
  }