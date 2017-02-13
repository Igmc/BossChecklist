#!/bin/sh

echo "Travis Script Start"

# 2nd run
if [ "$TRAVIS_TAG" ]; then
	echo "TRAVIS_TAG is set";
	exit 0;
fi


tags=`git tag`
echo "tags are $tags"

#version=`curl http://javid.ddns.net/tModLoader/tools/latestmodversionsimple.php?modname=CheatSheet`
echo "version is $version"
if [ "$version" = "v0.2.5.13" ]; then 
	echo "Version does match, no need to push release";
	exit 0;
else 
	echo "Version does not match, need to push release";
	git config --global user.email "builds@travis-ci.com"
	git config --global user.name "Travis CI"
	#export GIT_TAG=v0.1.1.6.4
	git tag $version -a -m "TravisCI Autogenerated Tag"
	git push --quiet https://$GH_REPO_TOKEN@github.com/JavidPack/BossChecklist $version > /dev/null 2>&1
	exit 0;
fi
echo "Travis Script End"

