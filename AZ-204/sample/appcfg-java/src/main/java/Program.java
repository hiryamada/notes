package testapp;

import com.azure.data.appconfiguration.ConfigurationClientBuilder;
import com.azure.data.appconfiguration.models.SecretReferenceConfigurationSetting;
import com.azure.identity.DefaultAzureCredential;
import com.azure.identity.DefaultAzureCredentialBuilder;
import com.azure.security.keyvault.secrets.SecretClientBuilder;

public class Program {
	// 認証情報（VMのマネージドIDなど）
	public static DefaultAzureCredential defaultCredential = new DefaultAzureCredentialBuilder().build();

	public static void main(String[] args) {

		// App Configurationのクライアントを作成
		var appConfigrationClient = new ConfigurationClientBuilder()//
				.credential(defaultCredential)//
				.endpoint("https://appcfg92837423.azconfig.io")//
				.buildClient();

		// 構成の取得
		var itemsPerPage = appConfigrationClient.getConfigurationSetting("ItemsPerPage", null);
		System.out.println(itemsPerPage.getValue());

		// Key Vault参照の取得
		var password1 = appConfigrationClient.getConfigurationSetting("password1", null);
		System.out.println(password1.getValue()); // シークレットのURLが出てくる

		// Key Vault参照の場合、getConfigurationSettingの戻り値は
		// SecretReferenceConfigurationSetting となる。
		if (password1 instanceof SecretReferenceConfigurationSetting) {
			var value = getSecretValue((SecretReferenceConfigurationSetting) password1);
			System.out.println(value);
		}
	}

	// SecretReferenceConfigurationSetting から、シークレットの値を取得する
	private static String getSecretValue(SecretReferenceConfigurationSetting setting) {

		// シークレットIDは "https://kv98273423.vault.azure.net/secrets/password1" といった形式。
		var secretId = setting.getSecretId();

		// "/secrets/"で分ける
		var arr = secretId.split("/secrets/");
		// 前半部分＝Key VaultのURL
		var uri = arr[0];
		// 後半部分＝シークレット名
		var secretName = arr[1];

		// Key Vaultシークレットのクライアントを作成
		var keyVaultClient = new SecretClientBuilder()//
				.vaultUrl(uri)//
				.credential(defaultCredential)//
				.buildClient();

		// Key Vaultシークレットを取得
		var secretValue = keyVaultClient.getSecret(secretName);

		// シークレットの値を取得
		return secretValue.getValue();
	}

}
