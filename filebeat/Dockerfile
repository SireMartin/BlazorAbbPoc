FROM docker.elastic.co/beats/filebeat:7.16.2
COPY --chown=root:filebeat filebeat.docker.yml /usr/share/filebeat/filebeat.yml
USER root
RUN chmod 644 /usr/share/filebeat/filebeat.yml
