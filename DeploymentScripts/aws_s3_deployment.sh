aws s3 mb s3://speakr-travisbuilds
aws s3api put-bucket-policy --bucket speakr-travisbuilds --policy file://aws_s3_permissions.json 