FROM mono:4.0.0-onbuild

EXPOSE 8088

CMD [ "mono", "./OwinWebAPIMono.exe" ]
