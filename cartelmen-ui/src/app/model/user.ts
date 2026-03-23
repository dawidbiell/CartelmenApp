export type User = {
  id: number;
  username: string;
  email: string;
  token: string;
};

export type UserCredentials = {
  email: string;
  password: string;
};

export type UserRegisterCredentials = {
  email: string;
  password: string;
  username: string;
};
