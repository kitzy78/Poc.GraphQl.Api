#!/bin/sh
cp /migrations/*.sql /docker-entrypoint-initdb.d/
mysqld
