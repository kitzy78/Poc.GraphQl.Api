FROM mysql/mysql-server:5.7.25 as builder

ENV MYSQL_ROOT_PASSWORD=testing
ENV MYSQL_DATABASE=productstore
ENV MYSQL_USER=tester
ENV MYSQL_PASSWORD=testing

CMD ["mysqld"]
EXPOSE 3306