
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

public class Task8_ConvertJSONToJavaClass {
    public static void main(String[] args) throws JsonProcessingException {
        String jsonString = "{\n" +
                "    \"model\": \"S3\",\n" +
                "    \"brand\": \"BMW\",\n" +
                "    \"manufacturerYear\": 2021}";
        Car volkswagenPassat = new ObjectMapper().readValue(jsonString, Car.class);

        System.out.println("Car brand: " + volkswagenPassat.getBrand());
        System.out.println("Car model: " + volkswagenPassat.getModel());
        System.out.println("Manufacturer year: " + volkswagenPassat.getManufacturerYear());
    }
}
