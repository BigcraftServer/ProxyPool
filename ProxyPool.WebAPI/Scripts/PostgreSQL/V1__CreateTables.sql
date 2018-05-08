CREATE TABLE "ProxyCountries"
(
  code VARCHAR(2) NOT NULL primary key,
  name VARCHAR(255) NOT NULL,
  UNIQUE (code,name)
);

create table "Proxies"(
  id uuid NOT NULL PRIMARY KEY DEFAULT uuid_generate_v4(),
  ip_address INET NOT NULL,
  port INTEGER NOT NULL,
  type varchar(20) NOT NULL,
  anonymous_type varchar(20) NOT NULL,
  country_code VARCHAR(2) NOT NULL REFERENCES "ProxyCountries",
  create_time DATE NOT NULL,
  UNIQUE(ip_address,type,port)
);