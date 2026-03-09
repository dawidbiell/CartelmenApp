export type User = {
  id: number;
  username: string;
  email: string;
  token: string;
};

export type UserCredentials = {
  username: string;
  password: string;
};

export type UserRegisterCredentials = {
  email: string;
  password: string;
  username: string;
};
