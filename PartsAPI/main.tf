provider "aws" {
  region = "us-east-1"
}

resource "aws_rds_instance" "postgres" {
  allocated_storage    = 20
  engine               = "postgres"
  instance_class       = "db.t3.micro"
  name                 = "partsdb"
  username             = "postgres"
  password             = "postgres"
  skip_final_snapshot  = true
}

resource "aws_ecs_cluster" "cluster" {
  name = "parts-api-cluster"
}

resource "aws_ecs_task_definition" "task" {
  family                   = "parts-api"
  container_definitions    = jsonencode([
    {
      name      = "partsapi",
      image     = " postgres:15/parts-api:latest",
      essential = true,
      portMappings = [{ containerPort = 80 }]
    }
  ])
  requires_compatibilities = ["FARGATE"]
  network_mode             = "awsvpc"
  cpu                      = "256"
  memory                   = "512"
}
